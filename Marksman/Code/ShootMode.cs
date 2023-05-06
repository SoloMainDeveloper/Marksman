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
        public static SpriteFont MainFont { get; set; }
        public static SpriteFont NotebookFont { get; set; }
        public static Texture2D Background { get; set; }
        public static Texture2D Target { get; set; }
        public static Texture2D Aimer { get; set; }
        public static Texture2D Notebook { get; set; }
        public static Texture2D BulletInfo { get; set; }
        public static Texture2D[] Shots { get; set; }
        public static List<Button> Buttons { get; set; }

        public static int centerX = 960;
        public static int targetCenterY;

        public static int dy = 0;
        public static int dx = 0;

        public static int windPowerX;
        public static int distance;
        public static Direction windDirectionX;
        public static double randomOffset;

        public static int score;
        public static int scorePerShot;
        public static int shotsDone;
        public static double lastShotOffsetX;
        public static double lastShotOffsetY;
        public static double lastShotDistance;
        public static List<Rectangle> shotsPos;

        public static void CreateLevel(int distanceToAim, int powerWindX, Direction directionWind, double randOffset)
        {
            distance = distanceToAim;
            windPowerX = powerWindX;
            windDirectionX = directionWind;
            randomOffset = randOffset;
            shotsPos = new();
            shotsDone = 0;
            lastShotOffsetY = 0;
            lastShotOffsetX = 0;
            scorePerShot = 0;
            score = 0;
            dx = 0;
            dy = 0;
        }

        public static void Shoot(object sender, EventArgs e)
        {
            var absOffsetX = GetBulletOffsetX(distance, windPowerX);
            var realOffsetX = windDirectionX == Direction.Left ? -absOffsetX : absOffsetX;
            var realOffsetY = GetBulletOffsetY(distance);
            var random = new Random();
            var randX = 1.5 - random.NextDouble() * randomOffset;
            var randY = 1.5 - random.NextDouble() * randomOffset;

            var playerOffsetX = dx * 0.75 * distance / 100;
            var playerOffsetY = dy * 0.75 * distance / 100;

            var offsetX = Math.Round(playerOffsetX + realOffsetX + randX, 2);
            lastShotOffsetX = offsetX;
            var offsetY = Math.Round(playerOffsetY + realOffsetY + randY, 2);
            lastShotOffsetY = offsetY;
            lastShotDistance = GetDistanceToCentreTarget();
            shotsPos.Add(new Rectangle((centerX - 10 + (int)(offsetX * 10)), (targetCenterY - 10 - (int)(offsetY * 10)), 20, 20));
            shotsDone++;
        }

        public readonly static Dictionary<(int, int), double> offsetWind308 = new()
        {
            { (2, 50), 0.5 },
            { (2, 100), 1 },
            { (2, 150), 2.5 },
            { (2, 200), 4 },
            { (2, 250), 7 },
            { (2, 300), 10 },
            { (2, 350), 15 },
            { (2, 400), 20 },

            { (4, 50), 1 },
            { (4, 100), 2 },
            { (4, 150), 5 },
            { (4, 200), 8 },
            { (4, 250), 14 },
            { (4, 300), 20 },
            { (4, 350), 30 },
            { (4, 400), 40 },

            { (8, 50), 2 },
            { (8, 100), 4 },
            { (8, 150), 11 },
            { (8, 200), 18 },
            { (8, 250), 29 },
            { (8, 300), 40 },
            { (8, 350), 62 },
            { (8, 400), 84 },
        };

        public readonly static Dictionary<int, double> offsetFalling150m = new()
        {
            { 50, 1.8 },
            { 100, 4 },
            { 150, 0 },
            { 200, -7.4 },
            { 250, -22.1 },
            { 300, -43.9 },
            { 350, -80 },
            { 400, -160 },
        };
    }
}