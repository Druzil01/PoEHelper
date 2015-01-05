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
        public Element HudRoot { get { return ReadObjectAt<Element>(0x3C); } }
        public Element HpGlobe { get { return ReadObjectAt<Element>(0x40); } }
        public Element ManaGlobe { get { return ReadObjectAt<Element>(0x44); } }
        public Element Flasks { get { return ReadObjectAt<Element>(0x4C); } }
        public Element XpBar { get { return ReadObjectAt<Element>(0x50); } }
        public Element MenuButton { get { return ReadObjectAt<Element>(0x54); } }
        public Element MenuPanel { get { return ReadObjectAt<Element>(0x58); } }
        public Element OptionsMenuItem { get { return ReadObjectAt<Element>(0x5C); } }
        public Element SocialMenuItem { get { return ReadObjectAt<Element>(0x60); } }
        public Element CharacterMenuItem { get { return ReadObjectAt<Element>(0x64); } }
        public Element SkillTreeMenuItem { get { return ReadObjectAt<Element>(0x68); } }
        public Element InventoryMenuItem { get { return ReadObjectAt<Element>(0x6C); } }
        public Element AchievementsMenuItem { get { return ReadObjectAt<Element>(0x70); } }
        public Element OptionsIconMenuItem { get { return ReadObjectAt<Element>(0x74); } }
        public Element WorldMapMenuItem { get { return ReadObjectAt<Element>(0x78); } }
        public Element OverlayMapMenuItem { get { return ReadObjectAt<Element>(0x7C); } }
        public Element ShopButton { get { return ReadObjectAt<Element>(0x80); } }
        public Element HideoutEditButton { get { return ReadObjectAt<Element>(0x84); } }
        public Element HideoutStashButton { get { return ReadObjectAt<Element>(0x88); } }
        public Element SkillPointAvailable { get { return ReadObjectAt<Element>(0x8C); } }
        public Element QuestInfoButton { get { return ReadObjectAt<Element>(0x90); } }
        public Element OpenChatButton { get { return ReadObjectAt<Element>(0x9C); } }
        public Element DragDropWindow { get { return ReadObjectAt<Element>(0xA0); } } 
        public Element ActionButtons { get { return ReadObjectAt<Element>(0xA4); } }
        //public Element SkillSelectWindow { get { return ReadObjectAt<Element>(0x4 + 0xA8); } }
        public Element PartyPanel { get { return ReadObjectAt<Element>(0xB0); } }
        public Element TopScreenPanel1 { get { return ReadObjectAt<Element>(0xB4); } }
        public Element TopScreenPanel2 { get { return ReadObjectAt<Element>(0xB8); } }
        public Element TopScreenPanel3 { get { return ReadObjectAt<Element>(0xBC); } }
        //public Element AskForPvp { get { return ReadObjectAt<Element>(0x4 + 0xB8); } }
        public Element TimerTopPanel { get { return ReadObjectAt<Element>(0xC4); } }

        public Element TopScreenPanel4 { get { return ReadObjectAt<Element>(0xC8); } }

        public Element LeftBottomPanel1 { get { return ReadObjectAt<Element>(0xCC); } }
        public Element LeftBottomPanel2 { get { return ReadObjectAt<Element>(0xD0); } }

        public Element CenterBottomPanel1 { get { return ReadObjectAt<Element>(0xD4); } }
        public Element CenterBottomPanel2 { get { return ReadObjectAt<Element>(0xD8); } }

        public Element Chat { get { return ReadObjectAt<Element>(0xE4); } } //+8 1.3d!!!
        //public Element Chat { get { return ReadObjectAt<Element>(0x4 + 0xDC); } }
        public Element QuestTracker { get { return ReadObjectAt<Element>(0xF0); } }
        //public Element MtxInventory { get { return ReadObjectAt<Element>(0x8 + 0xF0); } }
        //public Element MtxShop { get { return ReadObjectAt<Element>(0x8 + 0xF4); } }
        //public InventoryPanel InventoryPanel { get { return ReadObjectAt<InventoryPanel>(0x8 + 0xF8); } }
        //public Element StashPanel { get { return ReadObjectAt<Element>(0x8 + 0xFC); } }
        //public Element SocialPanel { get { return ReadObjectAt<Element>(0x8 + 0x108); } }
        //public Element TreePanel { get { return ReadObjectAt<Element>(0x8 + 0x10c); } }
        //public Element CharacterPanel { get { return ReadObjectAt<Element>(0x8 + 0x110); } }
        //public Element OptionsPanel { get { return ReadObjectAt<Element>(0x8 + 0x114); } }
        //public Element AchievementsPanel { get { return ReadObjectAt<Element>(0x8 + 0x118); } }
        //public Element WorldPanel { get { return ReadObjectAt<Element>(0x8 + 0x11C); } }
        public BigMinimap Minimap { get { return ReadObjectAt<BigMinimap>(0x12C); } } //+4 1.3d
        //public Element ItemsOnGroundLabels { get { return ReadObjectAt<Element>(0x8 + 0x124); } }
        //public Element MonsterHpLabels { get { return ReadObjectAt<Element>(0x8 + 0x128); } }
        //public Element Buffs { get { return ReadObjectAt<Element>(0x8 + 0x134); } }
        //public Element Buffs2 { get { return ReadObjectAt<Element>(4 + 0x8 + 0x18c); } }
        //public Element OpenLeftPanel { get { return ReadObjectAt<Element>(0x8 + 0x158); } }
        //public Element OpenRightPanel { get { return ReadObjectAt<Element>(0x8 + 0x15c); } }
        //public Element OpenNpcDialogPanel { get { return ReadObjectAt<Element>(0x8 + 0x164); } }
        //public Element CreatureInfoPanel { get { return ReadObjectAt<Element>(0x8 + 0x188); } }
        public Element DropItemWindow1 { get { return ReadObjectAt<Element>(0x1AC); } }
        public Element DropItemWindow2 { get { return ReadObjectAt<Element>(0x1B8); } }
        //public Element SwitchingZoneInfo { get { return ReadObjectAt<Element>(0x8 + 0x1C8); } } // dunno what it is
        //public Element InstanceManagerPanel { get { return ReadObjectAt<Element>(0x8 + 0x19c); } }
        //public Element InstanceManagerPanel2 { get { return ReadObjectAt<Element>(0x8 + 0x200); } }
        public Element GemLvlUpPanel { get { return ReadObjectAt<Element>(0x20C); } }
        public Element ItemOnGroundTooltip { get { return ReadObjectAt<ItemOnGroundTooltip>(20 + 0x208); } }
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
