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
        public static List<Button> LevelButtons { get; set; }

        public static void CreateLevel()
        {
            switch (Main.Level)
            {
                case 1:
                    ShootMode.CreateLevel(150, 4, Direction.Left, 4.5, 26);
                    break;
                case 2:
                    ShootMode.CreateLevel(300, 2, Direction.Right, 9, 26);
                    break;
                case 3:
                    ShootMode.CreateLevel(200, 8, Direction.Left, 6, 26);
                    break;
                case 4:
                    ShootMode.CreateLevel(50, 4, Direction.Right, 1.5, 26);
                    break;
                case 5:
                    ShootMode.CreateLevel(250, 2, Direction.Left, 7.5, 26);
                    break;
                case 6:
                    ShootMode.CreateLevel(400, 8, Direction.Right, 12, 26);
                    break;
                default:
                    Main.Level = 1;
                    break;
            }
        }
    }
}
