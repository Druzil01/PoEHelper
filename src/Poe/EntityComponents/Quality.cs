namespace PoeHUD.Poe.EntityComponents
{
	public class Quality : Component
	{
		public int ItemQuality
		{
			get
			{
				if (this.Address != 0)
				{
					return this.m.ReadInt(this.Address + 12);
				}
				return 0;
			}
		}
	}
}
