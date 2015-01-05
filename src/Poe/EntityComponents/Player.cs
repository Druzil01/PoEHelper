namespace PoeHUD.Poe.EntityComponents
{
	public class Player : Component
	{
		public string PlayerName
		{
			get
			{
				if (this.Address == 0)
				{
					return "";
				}
				int num = this.m.ReadInt(this.Address + 32);
				if (num > 512)
				{
					return "";
				}
				if (num < 8)
				{
					return this.m.ReadStringU(this.Address + 16, num * 2, true);
				}
				return this.m.ReadStringU(this.m.ReadInt(this.Address + 16), num * 2, true);
			}
		}
		public long XP
		{
			get
			{
				if (this.Address != 0)
				{
					return (long)((ulong)this.m.ReadUInt(this.Address + 52));
				}
				return 0L;
			}
		}
		public int Level
		{
			get
			{
				if (this.Address != 0)
				{
					return this.m.ReadInt(this.Address + 68);
				}
				return 1;
			}
		}
	}
}
