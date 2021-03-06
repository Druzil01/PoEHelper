namespace PoeHUD.Poe.EntityComponents
{
	public class Chest : Component
	{
		public bool IsOpened
		{
			get
			{
				return this.Address != 0 && this.m.ReadByte(this.Address + 36) == 1;
			}
		}
		public bool IsStrongbox
		{
			get
			{
				return this.Address != 0 && this.m.ReadInt(this.Address + 52) != 0;
			}
		}
	}
}
