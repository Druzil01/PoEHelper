using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using PoeHUD.Framework;
using PoeHUD.Poe;
using PoeHUD.Game;
using PoeHUD.Poe.EntityComponents;
using PoeHUD.Poe.UI;
using SlimDX.Direct3D9;
using System.Linq;
using System;


namespace PoeHUD.Hud.debugwin
{
    class debugWindowRenderer : HUDPluginBase
    {
        private int lines;
        //private Rect destWin;
        private int textX;
        private int textY;
        private MouseHook hook;
        private Vec2 Mousepos;

        public debugWindowRenderer()
        {
        }

        public override void OnEnable()
        {
            this.hook = new MouseHook(new MouseHook.MouseEvent(this.OnMouseEvent));
        }

        public override void OnDisable()
        {
            this.hook.Dispose();
        }

        private bool OnMouseEvent(MouseEventID id, int x, int y)
        {
            if (Settings.GetBool("Window.RequireForeground") && !this.model.Window.IsForeground())
            {
                return false;
            }
            Mousepos = this.model.Window.ScreenToClient(new Vec2(x, y));
            if (id == MouseEventID.MouseMove)
            {
            }
            return false;
        }


        private int addLine(RenderingContext rc,string t)
        {
            rc.AddTextWithHeight(new Vec2(textX , textY + (lines * 12)), t, Color.White, 8, DrawTextFormat.Left);
            lines++;
            return 1;
        }

        public override void Render(RenderingContext rc, Dictionary<UiMountPoint, Vec2> mountPoints)
        {
            if (Settings.GetBool("debug"))
            {
                rc.AddTextWithHeight(new Vec2(1, 1), Mousepos.X.ToString()+ " - " + Mousepos.Y.ToString(), Color.White, 8, DrawTextFormat.Left);
                //ItemDebug();

                //Element uiHover = this.model.Internal.IngameState.UIHover;
                //Dictionary<string, int> comp = new Dictionary<string, int>();
                ////if (uiHover != null)
                ////{
                //    Entity itm = uiHover.AsObject<InventoryItemIcon>().Item;
                //    Mods Mo = itm.GetComponent<Mods>();
                //    //if (itm.ID != 0 && itm.IsValid)
                //    //{
                //        comp = itm.GetComponents();

                ////    }
                ////}



                Element mm = this.model.Internal.game.IngameState.IngameUi.Minimap.SmallMinimap;
                Element qt = this.model.Internal.game.IngameState.IngameUi.QuestTracker;
                Element gl = this.model.Internal.game.IngameState.IngameUi.GemLvlUpPanel;
                Rect miniMapRect = mm.GetClientRect();
                Rect qtRect = qt.GetClientRect();
                Rect glRect = gl.GetClientRect();

                Rect clientRect = miniMapRect;


                if (qt.IsVisible && qtRect.Y>0)
                    clientRect = qtRect;
                if (gl.IsVisible && glRect.Y>0)
                    clientRect = glRect;

                lines = 0;
                textX = miniMapRect.X;
                textY = clientRect.Y + clientRect.H + 20;
                lines += ShowAdresses(rc);
                lines += AddPlayerinfo(rc);

                //ShowOpenUiWindows(rc);
                //DrawOpenWindows(rc);
                //showInGameUI(rc);
                //ShowAllUiWindows(rc);

                Rect destWin = new Rect(miniMapRect.X, clientRect.Y + clientRect.H + 20, miniMapRect.W, clientRect.H + 12 * lines);
                rc.AddBox(destWin, Color.FromArgb(180, 0, 0, 0));
                rc.AddFrame(destWin, Color.Gray, 2);

                showElementChilds(rc, this.model.Internal.IngameState.IngameUi.InventoryPanel);
                showElementChilds(rc, this.model.Internal.IngameState.IngameUi.Flasks);
                showElementChilds(rc, this.model.Internal.IngameState.IngameUi.ItemsOnGroundLabels);
                //showElementChilds(rc, this.model.Internal.IngameState.IngameUi.OpenNpcDialogPanel); // <- offset 160
                //showElementChilds(rc, this.model.Internal.IngameState.IngameUi.ItemOnGroundTooltip); // <- offset 160
                //showElementChilds(rc, this.model.Internal.IngameState.IngameUi.ItemsOnGroundLabels); // <- offset 160
            }
        }


        private void ItemDebug()
        {
            Element uiHover = this.model.Internal.IngameState.UIHover;
            Dictionary<string, int> comp = new Dictionary<string,int>();
            if (uiHover != null)
            {
                Entity itm = uiHover.AsObject<InventoryItemIcon>().Item;
                Mods Mo = itm.GetComponent<Mods>();
                if (itm.ID != 0 && itm.IsValid)
                {
                    comp = itm.GetComponents();
                    
                }
            }
        }

        /// <summary>
        /// Draws a frame and an Alpha blend Box around the Element 
        /// </summary>
        /// <param name="rc">the Display </param>
        /// <param name="ele">Element to display</param>
        /// <param name="col">Color</param>
        /// <param name="width">Width of the border</param>
        /// <param name="txt">Text to display</param>
        private void ShowElement(RenderingContext rc,Element ele,Color col, int width,string txt)
        {
            Rect Re = ele.GetClientRect();
            if (Re.H > 0)
            {
                int rnd = new Random().Next(0, Re.H+1);
                rnd = 0;
                //rc.AddBox(Re, Color.FromArgb(230, 0, 0, 0));
                if (Re.HasPoint(Mousepos))
                {
                    col = Color.LightCyan;
                    rc.AddFrame(Re, col, width+2);
                    rc.AddTextWithHeight(new Vec2(Re.X+4, Re.Y+4+rnd), txt, col, 8, DrawTextFormat.Left);
                }
                else
                {
                    rc.AddFrame(Re, col, width);
                }
            }
        }


        private void showElementChilds(RenderingContext rc, Element Base)
        {
            showElementChilds(rc, Base, 0,4,"0");
        }
        private void showElementChilds(RenderingContext rc, Element Base,int current,int max, string path)
        {
            Color[] cols = new Color[5] { Color.Red, Color.Green, Color.LightBlue, Color.Gold, Color.Cyan };
            if (Base.IsVisible && Base.Height > 0)
            {
                //ShowElement(rc, Base, cols[current], max - current, current.ToString() + "|" + Base.address.ToString("X8"));
                ShowElement(rc, Base, cols[current], max - current, path);// + "|" + Base.address.ToString("X8"));
                foreach (Element e in Base.Children)
                {
                    if (current < max)
                        showElementChilds(rc, e, current + 1, max,path +"-" +(current+1).ToString());
                }
            }
        }

        private void showInGameUI(RenderingContext rc)
        {
            for (int i = 0; i <= 420; i++) //Just a guess .. can be a lot more
            {
                int offs = i * 4;
                Element el = this.model.Internal.IngameState.IngameUi.ReadObjectAt<Element>(offs);

                bool known = false;
                PropertyInfo[] prop = typeof(IngameUIElements).GetProperties();
                foreach (PropertyInfo p in prop)
                {
                    var m = p.MemberType;
                    if (p.PropertyType == typeof(Element) || p.PropertyType.BaseType == typeof(Element))
                    {
                        if (p.CanRead)
                        {
                            Element b = (Element)p.GetValue(this.model.Internal.game.IngameState.IngameUi, null);
                            known = known || b.address == el.address;
                        }
                    }
                }

                if (known)
                {
                    //ShowElement(rc, el, Color.Red, 2, offs.ToString("X3"));
                }
                else
                {
                    ShowElement(rc, el, Color.Gold, 1, offs.ToString("X3"));
                }
            }
        }

        private void ShowAllUiWindows(RenderingContext rc)
        {
            //Most parts taken from ShowUIHierarchy

            Element root = this.model.Internal.IngameState.UIRoot;
            int[] path = new int[12];
            for (path[0] = 0x80; path[0] <= 0x210; path[0] += 4)
            {

                if (path[0] == 0x120 || path[0] == 0xd8 || path[0] == 0xa0 || path[0] == 0x154 || path[0] == 0x158)
                    continue;

                Element starting_it = this.model.Internal.IngameState.IngameUi.ReadObjectAt<Element>(path[0]);
                
                DrawWin(rc, starting_it, path,1,2,true);
            }
        }

        private void DrawWin(RenderingContext rc, Element start, int[] path,int depth,int maxdeep,bool onlyUnknown)
        {
            bool known = false;
            PropertyInfo[] prop = typeof(IngameUIElements).GetProperties();
            foreach (PropertyInfo p in prop)
            {
                var m = p.MemberType;
                if (p.PropertyType == typeof(Element) || p.PropertyType.BaseType == typeof(Element))
                {
                    if (p.CanRead)
                    {
                        Element b = (Element)p.GetValue(this.model.Internal.game.IngameState.IngameUi, null);
                        known = known || b.address == start.address;
                    }
                }
            }

            //if ((onlyUnknown && !known) || (!onlyUnknown))
            //{
            if (known) {
                //Most parts taken from ShowUIHierarchy
                Rect Re = start.GetClientRect();

                //string sPath = path[0].ToString("X3") + "-" + string.Join("-", path.Skip(1).Take(depth - 1));
                //int ix = depth > 0 ? path[depth - 1] : 0;
                //var c = Color.FromArgb(255, 255 - 25 * (ix % 10), 255 - 25 * ((ix % 100) / 10), 255);
                Color c = Color.Gray; 
                if (depth==1) c = Color.Red;
                //string msg = string.Format("[{2}] {1:X8} : {0}", Re, start.address, sPath);
                //rc.AddTextWithHeight(new Vec2(Re.X, Re.Y + depth * 10 - 10), sPath, c, 8, DrawTextFormat.Left);
                rc.AddFrame(Re, c);
                for (int i = 0; i < start.Children.Count; i++)
                {
                    Element child = start.Children[i];
                    path[depth] = i;
                    if (depth <= maxdeep)
                        DrawWin(rc, child, path, depth + 1, maxdeep, onlyUnknown);
                }
            }
        }


        private int ShowAdresses(RenderingContext rc)
        {
            int l = 0;
            string form;
            if (Settings.GetBool("debug.Display"))
                form = "";
            else
                form = "X8";
            l += addLine(rc, "game:" +                   this.model.Internal.game.address.ToString(form));
            l += addLine(rc, "game.ingamestate:" + this.model.Internal.game.IngameState.address.ToString(form));
            l += addLine(rc, "ingamestate.inggameUI :" + this.model.Internal.game.IngameState.IngameUi.address.ToString(form));
            l += addLine(rc, "ingamestate.UIRoot:" + this.model.Internal.game.IngameState.UIRoot.address.ToString(form));
            l += addLine(rc, "ingamestate.ServerData:" + this.model.Internal.IngameState.ServerData.address.ToString(form));
            l += addLine(rc, "Flasks:" + this.model.Internal.IngameState.ServerData.FlaskInventoryBase.address.ToString(form));
            l += addLine(rc, "UiBase :" + this.model.Internal.game.IngameState.ServerData.UiBase.address.ToString(form));
            //l += addLine(rc, "Playerinv:" + this.model.Internal.IngameState.ServerData.PlayerInventories.address.ToString(form));
            l += addLine(rc, "Playerbase :" + this.model.Player.Address.ToString(form));
            l += addLine(rc, "PlayerLife:" + this.model.Player.GetComponent<Life>().address.ToString(form));
            return l;
        }

        private int AddPlayerinfo(RenderingContext rc)
        {
            Life l = this.model.Player.GetComponent<Life>();
            addLine(rc, "Health =" + l.CurHP + "/" + l.MaxHP);
            foreach (Poe.Buff b in l.Buffs)
            {
                addLine(rc, b.Name + " (" + b.Timer.ToString() + ")");
            }
            addLine(rc, "----------------------------------");
            return 2 + l.Buffs.Count();
        }

        private void ShowOpenUiWindows(RenderingContext rc)
        {
            PropertyInfo[] prop = typeof(IngameUIElements).GetProperties();
            foreach (PropertyInfo p in prop)
            {
                var m = p.MemberType;
                if (p.PropertyType == typeof(Element) || p.PropertyType.BaseType == typeof(Element))
                {
                    string output = p.Name;
                    if (p.CanRead)
                    {
                        Element b = (Element)p.GetValue(this.model.Internal.game.IngameState.IngameUi, null);
                        if (b.IsVisible && b.Width > 0 && b.Height > 0)
                        {
                                
                            output += string.Format(": {0} (x={1} y={2} w={3} h={4} )", b.IsVisible ? "o" : "c", b.X, b.Y, b.Width, b.Height);
                            addLine(rc, output);
                        }
                    }
                    
                }
            }
        }

        private void DrawOpenWindows(RenderingContext rc)
        {
            PropertyInfo[] prop = typeof(IngameUIElements).GetProperties();
            foreach (PropertyInfo p in prop)
            {
                var m = p.MemberType;
                if (p.PropertyType == typeof(Element) || p.PropertyType.BaseType == typeof(Element))
                {
                    string output = p.Name;
                    if (p.CanRead)
                    {
                        Element b = (Element)p.GetValue(this.model.Internal.game.IngameState.IngameUi, null);
                        if (b.IsVisible && b.Width > 0 && b.Height > 0)
                        {
                            Rect Re = b.GetClientRect();
                            Re = new Rect(Re.X, Re.Y, Re.W, Re.H);
                            rc.AddFrame(Re, Color.Gold, 1);
                            rc.AddTextWithHeight(new Vec2(Re.X, Re.Y), p.Name, Color.White, 6, DrawTextFormat.Left);
                        }
                    }

                }

            }
        }
    }
}



