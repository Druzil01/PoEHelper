using System.Collections.Generic;
//using PoeHUD.Hud.Debug;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PoeHUD.Controllers;
using PoeHUD.Framework;
using PoeHUD.Hud.DebugView;
using PoeHUD.Hud.DPS;
using PoeHUD.Hud.Health;
using PoeHUD.Hud.Icons;
using PoeHUD.Hud.Loot;
using PoeHUD.Hud.MaxRolls;
using PoeHUD.Hud.Monster;
using PoeHUD.Hud.Preload;
using PoeHUD.Hud.XpRate;
using PoeHUD.Hud.debugwin;
using PoeHUD.Hud.Gemleveling;
using PoeHUD.Hud.KillCount;

namespace PoeHUD.Hud
{

    public class OverlayRenderer
    {
        private readonly List<HUDPlugin> plugins;
        private readonly GameController gameController;
        private int _modelUpdatePeriod;
        public OverlayRenderer(GameController gameController, RenderingContext rc)
        {
            this.gameController = gameController;
            gameController.Area.OnAreaChange += area => _modelUpdatePeriod = 6;

            this.plugins = new List<HUDPlugin>{
				new HealthBarRenderer(),
				new ItemAlerter(),
				new MinimapRenderer(gatherMapIcons),
				new LargeMapRenderer(gatherMapIcons),
				new ItemLevelRenderer(),
				new ItemRollsRenderer(),
				new MonsterTracker(),
				new PoiTracker(),
				new XPHRenderer(),
				new ClientHacks(),
                new debugWindowRenderer(),
                new GemLeveling(),
	#if DEBUG
				// new ShowUiHierarchy(),
                //new MainAddresses(),
	#endif
				new PreloadAlert(),
				new DpsMeter(),
                new KillCounter()
			};
            if (Settings.GetBool("Window.ShowIngameMenu"))
            {
//#if !DEBUG
				this.plugins.Add(new Menu.Menu());
//#endif
            }
            UpdateObserverLists();
            rc.OnRender += this.rc_OnRender;

            this.plugins.ForEach(x => x.Init(gameController));
        }

        private void UpdateObserverLists()
        {
            EntityListObserverComposite observer = new EntityListObserverComposite();
            observer.Observers.AddRange(plugins.OfType<EntityListObserver>());
            gameController.EntityListObserver = observer;
        }

        private IEnumerable<MapIcon> gatherMapIcons()
        {
            foreach (HUDPlugin plugin in plugins)
            {
                HUDPluginWithMapIcons iconSource = plugin as HUDPluginWithMapIcons;
                if (iconSource != null)
                {
                    // kvPair.Value.RemoveAll(x => !x.IsEntityStillValid());
                    foreach (MapIcon icon in iconSource.GetIcons())
                        yield return icon;
                }
            }
        }

        private void rc_OnRender(RenderingContext rc)
        {
            if (Settings.GetBool("Window.RequireForeground") && !this.gameController.Window.IsForeground()) return;

            this._modelUpdatePeriod++;
            if (this._modelUpdatePeriod > 6)
            {
                this.gameController.RefreshState();
                this._modelUpdatePeriod = 0;
            }

            bool ingame = this.gameController.InGame;

            if (!ingame || this.gameController.Player == null)
            {
                return;
            }

            Dictionary<UiMountPoint, Vec2> mountPoints = new Dictionary<UiMountPoint, Vec2>();
            mountPoints[UiMountPoint.UnderMinimap] = gameController.Internal.IngameState.IngameUi.GetRightTopUnderMinimap();
            mountPoints[UiMountPoint.LeftOfMinimap] = gameController.Internal.IngameState.IngameUi.GetRightTopLeftOfMinimap();

            foreach (HUDPlugin current in this.plugins)
            {
                current.Render(rc, mountPoints);
            }
        }

        //public void KeyPressOnForm(object sender, KeyPressEventArgs args)
        //{
        //    if (args.KeyChar == 'b')
        //    {
        //        Clipboard.SetText(new IdcScriptMaker(gameController).GetBaseAddressScript());
        //    }
        //}

        //private string PrepareIdcScript()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    return sb.ToString();
        //}


        public bool Detach()
        {
            foreach (HUDPlugin current in this.plugins)
                current.OnDisable();
            return false;
        }
    }

    public enum UiMountPoint
    {
        UnderMinimap,
        LeftOfMinimap
    }
}
