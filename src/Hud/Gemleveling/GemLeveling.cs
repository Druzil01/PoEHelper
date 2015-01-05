﻿using System;
using System.Collections.Generic;
using System.Drawing;
using PoeHUD.Framework;
using PoeHUD.Poe;
using PoeHUD.Game;
using PoeHUD.Poe.EntityComponents;
using PoeHUD.Poe.UI;
using SlimDX.Direct3D9;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace PoeHUD.Hud.Gemleveling
{
    class GemLeveling : HUDPluginBase
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref Point lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, Int32 wParam, Int32 lParam);

        public const int WM_CHAR = 0x102;
        public const int  WM_SETTEXT = 0xC;
        public const int  WM_KEYDOWN = 0x100;
        public const int  WM_KEYUP = 0x101;
        public const int  WM_LBUTTONDOWN = 0x201;
        public const int  WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;
        public const int  WM_CLOSE = 0x10;
        public const int  WM_COMMAND = 0x111;
        public const int  WM_CLEAR = 0x303;
        public const int  WM_DESTROY = 0x2;
        public const int  WM_GETTEXT = 0xD;
        public const int  WM_GETTEXTLENGTH = 0xE;
        public const int  WM_LBUTTONDBLCLK = 0x20;
        public const int WM_MOUSEMOVE = 0x200;
        public const int WM_MOUSEWHEEL = 0x020A;


        public static int makeWORD(Point P)
        {
            //check lparam
            int lparam = ((P.Y << 16) | (P.X & 0xffff));
            return lparam;
        }


        public void DoMouseClick(int X, int Y )
        {

            Point p = new Point(X, Y);

            var value = makeWORD(p);

            SendMessage(this.model.Window.Process.MainWindowHandle, WM_MOUSEMOVE, IntPtr.Zero, ref p);
            SendMessage(this.model.Window.Process.MainWindowHandle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(this.model.Window.Process.MainWindowHandle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        }


        public override void OnEnable()
        {
        }

        public override void OnDisable()
        {
        }

        public override void Render(RenderingContext rc, Dictionary<UiMountPoint, Vec2> mountPoints)
        {
            Element glw = this.model.Internal.IngameState.IngameUi.GemLvlUpPanel;
            if (glw.IsVisible && glw.Height >0)
            {
                Rect r = glw.GetClientRect();
                foreach (Element e in glw.Children) // there is a subwindow for every Gem to level
                {

                    Rect Re = e.GetClientRect();
                    rc.AddTextWithHeight(new Vec2(Re.X + 4, Re.Y + 4), e.Address.ToString ("X8"), Color.White, 8, DrawTextFormat.Left);
                    if (e.Active)
                        rc.AddFrame(Re, Color.Gold, 2);
                    else
                        rc.AddFrame(Re, Color.Gray, 2);

                    Console.WriteLine ("lvlup "+glw.Children.IndexOf(e).ToString() +" at "+e.Address.ToString("X8"));
                    Element LevelUpButton = e.Children[1]; // Element for the levelUp Button
                    if (LevelUpButton.IsVisible && LevelUpButton.Height > 0)
                    {
                        Rect lur = LevelUpButton.GetClientRect();
                        
                        //rc.AddFrame(r, Color.Gold, 2); // should only be display one time, but who cares
                        if (LevelUpButton.Active)
                            rc.AddFrame(lur, Color.Gold, 1);
                        else
                            rc.AddFrame(lur, Color.Gray, 1);

                        //DoMouseClick(lur.X + lur.W / 2, lur.Y + lur.H / 2);
                    }
                    
                }
            }
        }
    }
}




