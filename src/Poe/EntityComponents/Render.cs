using PoeHUD.Framework;

namespace PoeHUD.Poe.EntityComponents
{
	public class Render : Component
	{
		public float X
		{
			get
			{
				if (this.Address != 0)
				{
					return this.m.ReadFloat(this.Address + 48);
				}
				return 0f;
			}
		}
		public float Y
		{
			get
			{
				if (this.Address != 0)
				{
					return this.m.ReadFloat(this.Address + 52);
				}
				return 0f;
			}
		}
		public float Z
		{
			get
			{
				if (this.Address != 0)
				{
					return this.m.ReadFloat(this.Address + 136);
				}
				return 0f;
			}
		}
		public Vec3 Pos
		{
			get
			{
				return new Vec3(this.X, this.Y, this.Z);
			}
		}
		public string DisplayName
		{
			get
			{
				if (this.Address == 0)
				{
					return "";
				}
				int num = this.m.ReadInt(this.Address + 88);
				if (num < 8)
				{
					return this.m.ReadStringU(this.Address + 72, 16, true);
				}
				return this.m.ReadStringU(this.m.ReadInt(this.Address + 72), 256, true);
			}
		}
	}
}
