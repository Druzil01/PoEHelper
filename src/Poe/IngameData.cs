namespace PoeHUD.Poe
{
	public class IngameData : RemoteMemoryObject
	{
		public AreaTemplate CurrentArea
		{
			get
			{
				return base.ReadObject<AreaTemplate>(this.Address + 8);
			}
		}

		public int CurrentAreaLevel
		{
			get
			{
				return this.m.ReadInt(this.Address + 12);
			}
		}
		public int CurrentAreaHash
		{
			get
			{
				return this.m.ReadInt(this.Address + 16);
			}
		}

		public Entity LocalPlayer
		{
			get
			{
				return base.ReadObject<Entity>(this.Address + 1440);
			}
		}
		public EntityList EntityList
		{
			get
			{
				//return base.GetObject<EntityList>(this.address + 1472); // 1.2 
                return base.GetObject<EntityList>(this.Address + 1476);
            }
		}
	}
}
