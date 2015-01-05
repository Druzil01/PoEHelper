namespace PoeHUD.Poe.UI
{
    public class ItemOnGroundTooltip : Element
    {
        public Entity Item
        {
            get
            {
                var address = m.ReadInt(Address + OffsetBuffers, 0, 0x964, 0x974);
                var entity = GetObject<Entity>(address);
                return entity;
            }
        }

        public Element ToolTip
        {
            get
            {
                return GetChildAtIndex(0);
            }
        }   
    }
}
