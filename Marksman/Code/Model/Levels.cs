using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marksman
{
    internal class Levels
    {
        public static List<Component> LevelButtons { get; set; }

        public static void CreateLevel()
        {
            Main.Level++;
            switch (Main.Level)
            {
                case 1:
                    ShootMode.CreateLevel(150, 4, Direction.Left, 4.5, 26);
                    break;
                case 2:
                    ShootMode.CreateLevel(300, 2, Direction.Right, 9, 26);
                    break;
                case 3:
                    ShootMode.CreateLevel(200, 8, Direction.Right, 6, 26);
                    break;
                default:
                    ShootMode.CreateLevel(150, 4, Direction.Left, 4.5, 26);
                    break;
                    //
            }
        }
    }
}
