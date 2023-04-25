using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marksman
{
    public class ShootMode
    {
        public static SpriteFont Font { get; set; }
        public static Texture2D Background { get; set; }
        public static Texture2D Target { get; set; }
        public static Texture2D Aimer { get; set; }
        public static Texture2D[] Shots { get; set; }
        public static List<Button> Buttons { get; set; }

        private static int centerX = 960;
        private static int targetCenterY;

        private static int dy = 0;
        private static int dx = 0;

        private static int windPowerX;
        private static int distance;
        private static Direction windDirectionX;
        private static double randomOffset;

        private static int shotsDone;
        private static List<Rectangle> shotsPos;

        public static void CreateLevel(int distanceToAim, int powerWindX, Direction directionWind, int randOffset)
        {
            distance = distanceToAim;
            windPowerX = powerWindX;
            windDirectionX = directionWind;
            randomOffset = randOffset;
            shotsPos = new();
            shotsDone = 0;
            dx = 0;
            dy = 0;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            targetCenterY = 10 + Target.Height / 2;
            var posXtarget = centerX - Target.Width / 2;
            var posXaimer = centerX - Aimer.Width / 2;
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.Draw(Target, new Rectangle(posXtarget, 10, Target.Width, Target.Height), Color.White);
            spriteBatch.Draw(Aimer, new Rectangle(posXaimer, 1080 - Aimer.Height, Aimer.Width, Aimer.Height), Color.White);
            spriteBatch.DrawString(Font, GetSign(dx) + dx, GetOffsetTextPosX(), Color.White);
            spriteBatch.DrawString(Font, GetSign(dy) + dy, GetOffsetTextPosY(), Color.White);
            foreach (var button in Buttons)
                button.Draw(gameTime, spriteBatch);
            var i = 0;
            foreach (var shot in shotsPos)
            {
                spriteBatch.Draw(Shots[i % 6], shot, Color.White);
                i++;
            }
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var button in Buttons)
                button.Update(gameTime);
        }

        public static void ClickAimerUp(object sender, EventArgs e) => dy++;
        public static void ClickAimerDown(object sender, EventArgs e) => dy--;
        public static void ClickAimerRight(object sender, EventArgs e) => dx++;
        public static void ClickAimerLeft(object sender, EventArgs e) => dx--;
        public static void ClickResetOffset(object sender, EventArgs e)
        {
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

            var playerOffsetX = dx * 0.75;
            var playerOffsetY = -dy * 0.75;

            var offsetX = (int)((playerOffsetX + realOffsetX + randX) * 10);
            var offsetY = (int)((playerOffsetY + realOffsetY + randY) * 10);
            shotsPos.Add(new Rectangle((centerX - 10 + offsetX), (targetCenterY - 10 + offsetY), 20, 20));
            shotsDone++;
        }

        private static double GetBulletOffsetX(int distance, int windX) => windX == 0 ? 0 : offsetWind308[(windX, distance)];

        private static double GetBulletOffsetY(int distance) => offsetFalling150m[distance];

        private static string GetSign(int x)
        {
            if (x > 0) return "+";
            if (x < 0) return string.Empty;
            return " ";
        }

        private static Vector2 GetOffsetTextPosX() => dx > 0 ? new(centerX - 32, 600) : new(centerX - 22, 600);

        private static Vector2 GetOffsetTextPosY() => dy > 0 ? new(1153, 779) : new(1163, 779);

        private static Dictionary<(int, int), double> offsetWind308 = new()
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

        private static Dictionary<int, double> offsetFalling150m = new()
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
