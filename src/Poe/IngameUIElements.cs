using PoeHUD.Framework;
using PoeHUD.Poe.UI;

namespace PoeHUD.Poe
{
    /// <summary>
    /// everyone can find These windows Via Guessing using the display of the Debugwindow wich shows th UI
    /// 
    /// </summary>
	public class IngameUIElements : RemoteMemoryObject
	{

		public Element HpGlobe { get { return ReadObjectAt<Element>(0x40); } }

		public Element ManaGlobe { get { return ReadObjectAt<Element>(0x44); } }

		public Element Flasks { get { return ReadObjectAt<Element>(0x4C); } }

		public Element XpBar { get { return ReadObjectAt<Element>(0x50); } }

		public Element MenuButton { get { return ReadObjectAt<Element>(0x54); } }

		public Element ShopButton { get { return ReadObjectAt<Element>(4+0x7C); } }

        public Element HideoutEditButton { get { return ReadObjectAt<Element>(0x84); } } // found by Druzil !

        public Element HideoutStashButton { get { return ReadObjectAt<Element>(0x88); } } // found by Druzil !

        public Element SkillPointAvailable { get { return ReadObjectAt<Element>(0x8C); } } // found by Druzil !

        public Element QuertInfoButton { get { return ReadObjectAt<Element>(0x90); } } // found by Druzil !

        public Element ChatButton { get { return ReadObjectAt<Element>(0x9C); } } // found by Druzil !

        public Element Mouseposition { get { return ReadObjectAt<Element>(0xA0); } } // Wrong name. its the DragDropFrame found by Druzil !

		public Element ActionButtons { get { return ReadObjectAt<Element>(0xA4); } }

        public Element SkillSelectWindow { get { return ReadObjectAt<Element>(0xA8); } } // found by Druzil !

		public Element Chat { get { return ReadObjectAt<Element>(4+0xD8); } }

		public Element QuestTracker { get { return ReadObjectAt<Element>(4+0xE8); } }

		public Element MtxInventory { get { return ReadObjectAt<Element>(4+0xEC); } }

		public Element MtxShop { get { return ReadObjectAt<Element>(4+0xF0); } }

        public InventoryPanel InventoryPanel { get { return ReadObjectAt<InventoryPanel>(0xF8); } }

		public Element StashPanel { get { return ReadObjectAt<Element>(4+0xF8); } }

		public Element SocialPanel { get { return ReadObjectAt<Element>(4+0x104); } }

		public Element TreePanel { get { return ReadObjectAt<Element>(4+0x108); } }

		public Element CharacterPanel { get { return ReadObjectAt<Element>(4+0x10C); } }

		public Element OptionsPanel { get { return ReadObjectAt<Element>(4+0x110); } }

		public Element AchievementsPanel { get { return ReadObjectAt<Element>(4+0x114); } }

		public Element WorldPanel { get { return ReadObjectAt<Element>(4+0x118); } }

		public BigMinimap Minimap { get { return ReadObjectAt<BigMinimap>(4+0x11C); } }

		public Element ItemsOnGroundLabels { get { return ReadObjectAt<Element>(4+0x120); } }

		public Element MonsterHpLabels { get { return ReadObjectAt<Element>(4+0x124); } }

		public Element Buffs { get { return ReadObjectAt<Element>(4+0x130); } }
		public Element Buffs2 { get { return ReadObjectAt<Element>(4+0x18c); } }

		public Element OpenLeftPanel { get { return ReadObjectAt<Element>(4+0x154); } }
		public Element OpenRightPanel { get { return ReadObjectAt<Element>(4+0x158); } }

		public Element OpenNpcDialogPanel { get { return ReadObjectAt<Element>(4+0x160); } }

		public Element CreatureInfoPanel { get { return ReadObjectAt<Element>(4+0x184); } } // above, it shows name and hp

		public Element InstanceManagerPanel { get { return ReadObjectAt<Element>(4+0x198); } }
		public Element InstanceManagerPanel2 { get { return ReadObjectAt<Element>(4+0x19C); } }

		// dunno what it is
		public Element SwitchingZoneInfo { get { return ReadObjectAt<Element>(0x1C8); } }

		public Element GemLvlUpPanel { get { return ReadObjectAt<Element>(4+0x1F8); } } // found by Druzil

		public Element ItemOnGroundTooltip { get { return ReadObjectAt<Element>(4+0x208); } }

        public Vec2 GetRightTopLeftOfMinimap()
        {
            Rect clientRect = Minimap.SmallMinimap.GetClientRect();
            return new Vec2(clientRect.X - 10, clientRect.Y + 5);
        }

        public Vec2 GetRightTopUnderMinimap()
        {
            var mm = Minimap.SmallMinimap;
            var gl = GemLvlUpPanel;
            Rect mmRect = mm.GetClientRect();
            Rect glRect = gl.GetClientRect();

            Rect clientRect;
            if (gl.IsVisible && glRect.X + gl.Width < mmRect.X + mmRect.X + 50) // also this +50 value doesn't seem to have any impact
                clientRect = glRect;
            else
                clientRect = mmRect;
            return new Vec2(mmRect.X + mmRect.W, clientRect.Y + clientRect.H + 10);
        }

	}
}