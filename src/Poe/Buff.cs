namespace PoeHUD.Poe
{
	public class Buff : RemoteMemoryObject
	{
		public string Name
		{
			get
			{
				return this.m.ReadStringU(this.m.ReadInt(this.Address + 4, 0), 256);
			}
		}
		public int Charges
		{
			get
			{
				return this.m.ReadInt(this.Address + 24);
			}
		}
		public int SkillID
		{
			get
			{
				return this.m.ReadInt(this.Address + 36);
			}
		}

		public float Timer
		{
			get
			{
				return this.m.ReadFloat(this.Address + 12);
			}
		}
	}
}
