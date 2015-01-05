using System;
using PoeHUD.Framework;

namespace PoeHUD.Poe
{
	public abstract class RemoteMemoryObject
	{
		public Memory m;
		public int Address;
		public TheGame game;
		public RemoteMemoryObject()
		{
		}

		protected Offsets Offsets { get { return this.m.offsets; } }

		public T GetObject<T>(int address) where T : RemoteMemoryObject, new()
		{
			T t = Activator.CreateInstance<T>();
			t.m = this.m;
			t.Address = address;
			t.game = this.game;
			return t;
		}

		public virtual T ReadObjectAt<T>(int offet) where T : RemoteMemoryObject, new()
		{
			return ReadObject<T>(Address + offet);
		}
		public T ReadObject<T>(int address) where T : RemoteMemoryObject, new()
		{
			T t = Activator.CreateInstance<T>();
			t.m = this.m;
			t.Address = this.m.ReadInt(address);
			t.game = this.game;
			return t;
		}
		public T AsObject<T>() where T : RemoteMemoryObject, new()
		{
			T t = Activator.CreateInstance<T>();
			t.m = this.m;
			t.Address = this.Address;
			t.game = this.game;
			return t;
		}
		public override bool Equals(object obj)
		{
			RemoteMemoryObject remoteMemoryObject = obj as RemoteMemoryObject;
			return remoteMemoryObject != null && remoteMemoryObject.Address == this.Address;
		}
		public override int GetHashCode()
		{
			return this.Address + base.GetType().Name.GetHashCode();
		}
	}
}
