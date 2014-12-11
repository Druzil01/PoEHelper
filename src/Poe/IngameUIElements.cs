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
		public Element ShopButton { get { return ReadObjectAt<Element>(0x80); } }
        public Element HideoutEditButton { get { return ReadObjectAt<Element>(0x84); } } 
        public Element HideoutStashButton { get { return ReadObjectAt<Element>(0x88); } } 
        public Element SkillPointAvailable { get { return ReadObjectAt<Element>(0x8C); } }
        public Element QuestInfoButton { get { return ReadObjectAt<Element>(0x90); } } 
        public Element ChatButton { get { return ReadObjectAt<Element>(0x9C); } } 
        public Element Mouseposition { get { return ReadObjectAt<Element>(0xA0); } } // Wrong name. 
		public Element ActionButtons { get { return ReadObjectAt<Element>(0xA4); } }
        public Element SkillSelectWindow { get { return ReadObjectAt<Element>(0xA8); } }
        public Element AskForPvp { get { return ReadObjectAt<Element>(0xB8); } } 
		public Element Chat { get { return ReadObjectAt<Element>(0xDC); } }
		public Element QuestTracker { get { return ReadObjectAt<Element>(0xEC); } }
		public Element MtxInventory { get { return ReadObjectAt<Element>(0xF0); } }
		public Element MtxShop { get { return ReadObjectAt<Element>(0xF4); } }
        public InventoryPanel InventoryPanel { get { return ReadObjectAt<InventoryPanel>(0xF8); } }
		public Element StashPanel { get { return ReadObjectAt<Element>(0xFC); } }
		public Element SocialPanel { get { return ReadObjectAt<Element>(0x108); } }
		public Element TreePanel { get { return ReadObjectAt<Element>(0x10c); } }
		public Element CharacterPanel { get { return ReadObjectAt<Element>(0x110); } }
		public Element OptionsPanel { get { return ReadObjectAt<Element>(0x114); } }
		public Element AchievementsPanel { get { return ReadObjectAt<Element>(0x118); } }
		public Element WorldPanel { get { return ReadObjectAt<Element>(0x11C); } }
		public BigMinimap Minimap { get { return ReadObjectAt<BigMinimap>(0x120); } }
		public Element ItemsOnGroundLabels { get { return ReadObjectAt<Element>(0x124); } }
		public Element MonsterHpLabels { get { return ReadObjectAt<Element>(0x128); } }
		public Element Buffs { get { return ReadObjectAt<Element>(0x134); } }
    	public Element Buffs2 { get { return ReadObjectAt<Element>(4+0x18c); } }
		public Element OpenLeftPanel { get { return ReadObjectAt<Element>(0x158); } }
		public Element OpenRightPanel { get { return ReadObjectAt<Element>(0x15c); } }
		public Element OpenNpcDialogPanel { get { return ReadObjectAt<Element>(0x164); } }
		public Element CreatureInfoPanel { get { return ReadObjectAt<Element>(0x188); } } 
		public Element InstanceManagerPanel { get { return ReadObjectAt<Element>(0x19c); } }
		public Element InstanceManagerPanel2 { get { return ReadObjectAt<Element>(0x200); } }
        public Element SwitchingZoneInfo { get { return ReadObjectAt<Element>(0x1C8); } } // dunno what it is
		public Element GemLvlUpPanel { get { return ReadObjectAt<Element>(0x1FC); } } 
		public Element ItemOnGroundTooltip { get { return ReadObjectAt<Element>(0x20C); } }

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
