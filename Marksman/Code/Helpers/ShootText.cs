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
        private static double GetBulletOffsetX(int distance, int windX) => windX == 0 ? 0 : offsetWind308[(windX, distance)];
        private static double GetBulletOffsetY(int distance) => offsetFalling150m[distance];
        private static string GetSign(int x)
        {
            if (x > 0) return "+";
            if (x < 0) return string.Empty;
            return " ";
        }
        private static double GetDistanceToCentreTarget()
        {
            return Math.Round(Math.Sqrt(lastShotOffsetX * lastShotOffsetX + lastShotOffsetY * lastShotOffsetY), 2);
        }
        private static double GetMark()
        {
            var mark = 10 - (int)lastShotDistance / 3;
            scorePerShot = mark;
            score += mark;
            return mark > 0 ? mark : 0;

        }
        private static string GetDirectionText()
        {
            switch (windDirectionX)
            {
                case Direction.Up:
                    return "вверх";
                case Direction.Down:
                    return "вниз";
                case Direction.Right:
                    return "вправо";
                case Direction.Left:
                    return "влево";
                default: return "нет ветра";
            }
        }
        private static string GetOffsetTextX() => lastShotOffsetX < 0 ? "влево" : "вправо";
        private static string GetOffsetTextY() => lastShotOffsetY < 0 ? "вниз" : "вверх";
        private static Vector2 GetOffsetTextPosX() => dx > 0 ? new(centerX - 32, 600) : new(centerX - 22, 600);
        private static Vector2 GetOffsetTextPosY() => dy > 0 ? new(1153, 779) : new(1163, 779);
    }
}
