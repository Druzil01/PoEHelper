namespace PoeHUD.Poe.UI
{
	public class InventoryItemIcon : Element
	{
		public Tooltip Tooltip
		{
			get
			{
                return base.ReadObject<Tooltip>(this.address + 0xAEC);
			}
		}
		public Entity Item
		{
			get
			{
				return base.ReadObject<Entity>(this.address + 0xB10);
			}
		}
	}
}
