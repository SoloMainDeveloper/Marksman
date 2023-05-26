using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marksman
{
    public partial class ShootMode
    {
        public static double GetBulletOffsetX(int distance, int windX) => windX == 0 ? 0 : GunsInfo.offsetXWind308[(windX, distance)];
        public static double GetBulletOffsetY(int distance) => GunsInfo.offsetY150m308[distance];
        public static string GetSign(int x)
        {
            if (x > 0) return "+";
            if (x < 0) return string.Empty;
            return " ";
        }
        public static double GetDistanceToCentreTarget()
        {
            return Math.Round(Math.Sqrt(LastShotOffsetX * LastShotOffsetX + LastShotOffsetY * LastShotOffsetY), 2);
        }
        public static int GetMark() => LastShotDistance > TargetSize ? 0 : 10 - (int)LastShotDistance / 3;
        public static string GetOffsetTextX() => LastShotOffsetX < 0 ? "влево" : "вправо";
        public static string GetOffsetTextY() => LastShotOffsetY < 0 ? "вниз" : "вверх";
        public static Vector2 GetOffsetTextPosX() => dx > 0 ? new(Main.CenterX - 32, 600) : new(Main.CenterX - 22, 600);
        public static Vector2 GetOffsetTextPosY() => dy > 0 ? new(1153, 779) : new(1163, 779);
        public static string GetDirectionText()
        {
            return WindDirectionX switch
            {
                Direction.Up => "вверх",
                Direction.Down => "вниз",
                Direction.Right => "вправо",
                Direction.Left => "влево",
                _ => "нет ветра",
            };
        }

        public static void ChangeDx(int diff) => dx += diff;
        public static void ChangeDy(int diff) => dy += diff;
        public static void ResetDxDy()
        {
            dx = 0;
            dy = 0;
        }
    }
}
