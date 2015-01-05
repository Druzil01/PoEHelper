namespace PoeHUD.Poe.UI
{
    //public class InventoryItemIcon : Element
    //{
    //    private readonly Func<Element> inventoryItemTooltip;
    //    private readonly Func<Element> itemInChatTooltip;
    //    private readonly Func<ItemOnGroundTooltip> toolTipOnground;
    //    private ToolTipType? toolTip;

    //    public InventoryItemIcon()
    //    {
    //        toolTipOnground = () => game.IngameState.IngameUi.ItemOnGroundTooltip;
    //        inventoryItemTooltip = () => ReadObject<Element>(Address + 0x88C);
    //        itemInChatTooltip = () => ReadObject<Element>(Address + 0x888);
    //    }

    //    private ToolTipType ToolTipType
    //    {
    //        get { return (ToolTipType)(toolTip ?? (toolTip = GetToolTipType())); }
    //    }


    //    public Element Tooltip
    //    {
    //        get
    //        {
    //            switch (ToolTipType)
    //            {
    //                case ToolTipType.ItemOnGround:
    //                    return toolTipOnground();
    //                case ToolTipType.InventoryItem:
    //                    return inventoryItemTooltip();
    //                case ToolTipType.ItemInChat:
    //                    return itemInChatTooltip();
    //            }
    //            return null;
    //        }
    //    }

    //    public Entity Item
    //    {
    //        get
    //        {
    //            switch (ToolTipType)
    //            {
    //                case ToolTipType.ItemOnGround:
    //                    return toolTipOnground().Item;
    //                case ToolTipType.InventoryItem:
    //                    return ReadObject<Entity>(Address + 0xb10);
    //            }
    //            return null;
    //        }
    //    }

    //    private ToolTipType GetToolTipType()
    //    {
    //        Element tlTipOnground = toolTipOnground().ToolTip;
    //        if (tlTipOnground != null && tlTipOnground.IsVisible)
    //            return ToolTipType.ItemOnGround;

    //        //if (itemInChatTooltip() != null && itemInChatTooltip().IsVisible)
    //        //    return ToolTipType.ItemInChat;

    //        if (inventoryItemTooltip() != null)
    //            return ToolTipType.InventoryItem;
    //        return ToolTipType.None;
    //    }
    //}

    //public enum ToolTipType
    //{
    //    None,
    //    InventoryItem,
    //    ItemOnGround,
    //    ItemInChat
    //}


    public class InventoryItemIcon : Element
    {
        public Tooltip Tooltip
        {
            get
            {
                return base.ReadObject<Tooltip>(this.Address + 0xAEC);
            }
        }
        public Entity Item
        {
            get
            {
                return base.ReadObject<Entity>(this.Address + 0xB10);
            }
        }
    }
}
