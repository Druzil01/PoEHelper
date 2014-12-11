namespace PoeHUD.Poe
{
	public class ServerData : RemoteMemoryObject
	{
		public bool IsInGame
		{
			get
			{
//				return this.m.ReadInt(this.address + 10872) == 3;
				return this.m.ReadInt(this.address + 0x2AF8) == 3;
			}
		}

        public InventorySet PlayerInventories 
        {
            get //getinventoryset
            { 
                return GetObject<InventorySet>(address + 0x2D50); 
            } 
        } 

		public InventorySet FlaskInventoryBase
		{
			get
			{
//				return base.GetObject<InventorySet>(this.address + 0x2900);
                int offs = this.m.ReadInt(this.address + 0x220);
                offs = this.m.ReadInt(offs + 0x04c  );
                offs = this.m.ReadInt(offs + 0x968);
                return base.GetObject<InventorySet>(offs);
                offs = this.m.ReadInt(offs + 0x984);

                //offs = this.m.ReadInt(offs + 0x20);
                return base.GetObject<InventorySet>(offs);


                //offs = this.m.ReadInt(offs + 0x0f8);
                //offs = this.m.ReadInt(offs + 0xa50);
                //offs = this.m.ReadInt(offs + 0x988);
                //offs = this.m.ReadInt(offs + 0xa44);
                //return base.GetObject<InventorySet>(offs);

			}
		}

        public UiBase UiBase 
        {
            get
            {
                int offs = this.m.ReadInt(this.address + 0x220);
                return base.GetObject<UiBase>(offs + 0x4C);
            }
        }
	}
}
