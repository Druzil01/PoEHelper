using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PoeHUD.Controllers;
using PoeHUD.Framework;
using PoeHUD.Poe.EntityComponents;
using SlimDX.Direct3D9;

namespace PoeHUD.Hud.dps
{
    public class WeaponDpsRenderer : HUDPluginBase
    {
        public override void OnEnable()
        {
        }

        public override void OnDisable()
        {
        }

        public override void Render(RenderingContext rc, Dictionary<UiMountPoint, Vec2> mountPoints)
        {
            //if (!Settings.GetBool("Tooltip") || !Settings.GetBool("Tooltip.ShowWeaponDps"))
            //    return;
            //Element uiHover = this.poe.Internal.IngameState.UIHover;
            //Poe.Entity Item = uiHover.AsObject<InventoryItemIcon>().Item;
            //if (Item.address == 0 || !Item.IsValid)
            //    return;
            //if (!Item.HasComponent<Weapon>()) // if its no weapon then leave
            //    return;
            //Weapon comp = Item.GetComponent<Weapon>();
            //List<ItemMod> expMods = Item.GetComponent<Mods>().ItemMods;


            //ItemStats stats = Item.GetComponent<Mods>().ItemStats;
            //float EleDPS = stats.GetStat(ItemStat.AverageElementalDamage);
            //float physDPS = stats.GetStat(ItemStat.PhysicalDPS);
            //float DPS = stats.GetStat(ItemStat.DPS);
            //Tooltip tooltip = uiHover.AsObject<InventoryItemIcon>().Tooltip;
            //if (tooltip == null)
            //    return;
            //Element childAtIndex1 = tooltip.GetChildAtIndex(0);
            //if (childAtIndex1 == null)
            //    return;
            //Element childAtIndex2 = childAtIndex1.GetChildAtIndex(1);
            //if (childAtIndex2 == null)
            //    return;
            //Rect clientRect = childAtIndex2.GetClientRect();
            //Rect headerRect = childAtIndex1.GetChildAtIndex(0).GetClientRect();

            //int tooltipBotY=clientRect.Y + clientRect.H;
            //int i = tooltipBotY;

            //foreach (MaxRolls_Current item in this.mods)
            //{
            //    rc.AddTextWithHeight(new Vec2(clientRect.X, i), item.name, item.color, 8, DrawTextFormat.Left);
            //    i += 20;
            //    rc.AddTextWithHeight(new Vec2(clientRect.X + clientRect.W - 100, i), item.max, Color.White, 8, DrawTextFormat.Left);
            //    rc.AddTextWithHeight(new Vec2(clientRect.X + 30, i), item.curr, Color.White, 8, DrawTextFormat.Left);
            //    i += 20;
            //    if (item.curr2 != null && item.max2 != null)
            //    {
            //        rc.AddTextWithHeight(new Vec2(clientRect.X + clientRect.W - 100, i), item.max2, Color.White, 8, DrawTextFormat.Left);
            //        rc.AddTextWithHeight(new Vec2(clientRect.X + 30, i), item.curr2, Color.White, 8, DrawTextFormat.Left);
            //        i += 20;
            //    }
            //}
            //if (i > tooltipBotY)
            //{
            //    Rect helpRect = new Rect(clientRect.X + 1, tooltipBotY, clientRect.W, i - tooltipBotY);
            //    rc.AddBox(helpRect, Color.FromArgb(220, Color.Black));
            //}
        }
    }
}



