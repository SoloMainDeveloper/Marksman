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

        private static int centerX = 960;
        private static int targetCenterY;

        public static int dy = 0;
        public static int dx = 0;

        private static int windPowerX;
        private static int distance;
        private static Direction windDirectionX;
        private static double randomOffset;

        private static int score;
        private static int scorePerShot;
        private static int shotsDone;
        private static double lastShotOffsetX;
        private static double lastShotOffsetY;
        private static double lastShotDistance;
        private static List<Rectangle> shotsPos;

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

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            targetCenterY = 10 + Target.Height / 2;
            var posXtarget = centerX - Target.Width / 2;
            var posXaimer = centerX - Aimer.Width / 2;
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.Draw(Target, new Rectangle(posXtarget, 10, Target.Width, Target.Height), Color.White);
            spriteBatch.Draw(Aimer, new Rectangle(posXaimer, 1080 - Aimer.Height, Aimer.Width, Aimer.Height), Color.White);

            var noteColor = Color.DarkBlue;
            spriteBatch.Draw(Notebook, new Rectangle(1510, 10, Notebook.Width, Notebook.Height), Color.White);
            spriteBatch.DrawString(NotebookFont, $"Дистанция: {distance}м", new(1595, 70), noteColor);
            spriteBatch.DrawString(NotebookFont, $"Ветер: {windPowerX}м/с", new(1595, 103), noteColor);
            spriteBatch.DrawString(NotebookFont, $"Направление ветра:", new(1595, 136), noteColor);
            spriteBatch.DrawString(NotebookFont, $"{GetDirectionText()}", new(1595, 169), noteColor);
            if (shotsDone != 0)
            {
                spriteBatch.DrawString(NotebookFont, "Последний выстрел:", new(1595, 202), Color.Red);
                spriteBatch.DrawString(NotebookFont, $"Откл. {GetOffsetTextX()}: {Math.Abs(lastShotOffsetX)}см", new(1595, 235), Color.Red);
                spriteBatch.DrawString(NotebookFont, $"Откл. {GetOffsetTextY()}: {Math.Abs(lastShotOffsetY)}см", new(1595, 268), Color.Red);
                spriteBatch.DrawString(NotebookFont, $"От центра: {lastShotDistance}см", new(1595, 301), Color.Red);
                spriteBatch.DrawString(NotebookFont, $"Оценка: {GetMark()}", new(1595, 334), Color.Red);
            }

            spriteBatch.Draw(BulletInfo, new Rectangle(20, 120, Notebook.Width, Notebook.Height), Color.White);
            DrawBulletInfo(gameTime, spriteBatch);

            spriteBatch.DrawString(MainFont, GetSign(dx) + dx, GetOffsetTextPosX(), Color.White);
            spriteBatch.DrawString(MainFont, GetSign(dy) + dy, GetOffsetTextPosY(), Color.White);
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

        private static void DrawBulletInfo(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var pos = new Vector2(145, 210);
            var info = new List<string>();
            info.Add("Снос по X");
            info.Add($"Ветер   {windPowerX} м/с");
            info.Add("Дист. м  Снос см");
            for (var i = 1; i < 9; i++)
            {
                var dist = i * 50;
                info.Add($"{dist}   {offsetWind308[(windPowerX, dist)]}");
            }
            foreach (var str in info)
            {
                spriteBatch.DrawString(NotebookFont, str, pos, Color.DarkBlue);
                pos += new Vector2(0, 25);
            }
        }

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
