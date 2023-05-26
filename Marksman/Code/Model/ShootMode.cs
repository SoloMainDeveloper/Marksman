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
        public static List<Button> Buttons { get; set; }
        public static readonly int targetCenterY = 10 + Textures.ShootTarget.Height / 2;

        public static int dy { get; private set; } = 0;
        public static int dx { get; private set; } = 0;
        public static int Distance { get; private set; } = 0;
        public static int WindPowerX { get; private set; }
        public static Direction WindDirectionX { get; private set; }
        public static double RandomOffset { get; private set; }
        public  static int ShotsDone { get; private set; }
        public static double LastShotOffsetX { get; private set; }
        public static double LastShotOffsetY { get; private set; }
        public static double LastShotDistance { get; private set; }
        public static List<Rectangle> ShotsPos { get; private set; }
        public static double TargetSize { get; private set; }

        public static void CreateLevel(int distanceToAim, int powerWindX, Direction directionWind, double randOffset, double targetSize)
        {
            Distance = distanceToAim;
            WindPowerX = powerWindX;
            WindDirectionX = directionWind;
            RandomOffset = randOffset;
            TargetSize = targetSize;
            ShotsPos = new();
            ShotsDone = 0;
            LastShotOffsetY = 0;
            LastShotOffsetX = 0;
            dx = 0;
            dy = 0;
        }

        public static void Shoot(object sender, EventArgs e)
        {
            var absOffsetX = GetBulletOffsetX(Distance, WindPowerX);
            var realOffsetX = WindDirectionX == Direction.Left ? -absOffsetX : absOffsetX;
            var realOffsetY = GetBulletOffsetY(Distance);
            var random = new Random();
            var randX = RandomOffset * (0.5 - random.NextDouble());
            var randY = RandomOffset * (0.5 - random.NextDouble());

            var playerOffsetX = dx * 0.75 * Distance / 100;
            var playerOffsetY = dy * 0.75 * Distance / 100;

            LastShotOffsetX = Math.Round(playerOffsetX + realOffsetX + randX, 2);
            LastShotOffsetY = Math.Round(playerOffsetY + realOffsetY + randY, 2);
            LastShotDistance = GetDistanceToCentreTarget();
            var mark = GetMark();
            if (mark > 0)
                ShotsPos.Add(new Rectangle(Main.WindowWidth / 2 - 10 + (int)(LastShotOffsetX * 10), targetCenterY - 10 - (int)(LastShotOffsetY * 10), 20, 20));
            ShotsDone++;
        }
    }
}