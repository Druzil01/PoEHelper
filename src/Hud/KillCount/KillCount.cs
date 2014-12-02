using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using PoeHUD.Controllers;
using PoeHUD.Framework;
using PoeHUD.Poe.EntityComponents;
using SlimDX.Direct3D9;

namespace PoeHUD.Hud.KillCount
{
    public class KillCounter : HUDPluginBase
    {
        private int counter = 0;         // Counter for Kills
        private HashSet<int> KillList;   // ID's of killed Mobs

        public override void OnEnable()
        {
            KillList = new HashSet<int>();
            model.Area.OnAreaChange += CurrentArea_OnAreaChange; // Add Area Change Event to This Mod to Reset Killcounter
        }

        public override void OnDisable()
        {
        }

        /// <summary>
        /// Reset Killcounter on Area Change
        /// </summary>
        /// <param name="area"></param>
        private void CurrentArea_OnAreaChange(AreaController area)
        {
            counter = 0;
            KillList.Clear(); // reset Visible Mob - list
        }

        public override void Render(RenderingContext rc, Dictionary<UiMountPoint, Vec2> mountPoints)
        {
            //if (!Settings.GetBool("KillCountDisplay"))
            //{
            //    return;
            //}
            int fontHeight = 10;
            // browse through every Hostile Monster in Range
            foreach (var monster in model.Entities.Where(e => e.HasComponent<Poe.EntityComponents.Monster>() && e.IsHostile))
            {
                if (!monster.IsAlive) // Monster still lives ?
                {
                    if (!KillList.Contains(monster.Id)) // not yet counted ?
                    {
                        KillList.Add(monster.Id); // add to list
                    }
                }
            }
            Vec2 baseMount = mountPoints[UiMountPoint.LeftOfMinimap];
            Vec2 currLine = baseMount;
            Vec2 tPos = rc.AddTextWithHeight(currLine, "Kills", Color.White, fontHeight, DrawTextFormat.Left); //Pos of the text
            currLine.Y += fontHeight; // next Line
            Vec2 kPos = rc.AddTextWithHeight(currLine, KillList.Count().ToString(), Color.White, fontHeight, DrawTextFormat.Right); // Pos of the actual kill number

            int textWith = Math.Max(tPos.X, kPos.X);
                
            Rect rect = new Rect(baseMount.X - 5 - textWith, baseMount.Y - 5, textWith +5, tPos.Y+  2 * fontHeight);
        }
    }
}
