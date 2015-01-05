namespace PoeHUD.Poe
{
    public class UiBase : RemoteMemoryObject
    {
        public UiBase Flaskdata
        {
            get
            {
                int offs = this.m.ReadInt(this.Address + 0x220);
                return base.GetObject<UiBase>(offs + 0x4C);
            }
        }
        
    }
}
