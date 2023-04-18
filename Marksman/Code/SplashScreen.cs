using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marksman
{
    internal class SplashScreen
    {
        public static Texture2D Background { get; set; }
        public static SpriteFont Font { get; set; }

        private static Color color;
        private static int timeCounter;
        private static int diff;

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Font, "Нажмите Enter, чтобы продолжить", new(1270, 1000), color);
        }

        public static void Update() => color = Color.FromNonPremultiplied(0, 0, 0, GetColorOfTime());

        public static int GetColorOfTime()
        {
            timeCounter = (timeCounter + diff) % 256;
            if (timeCounter == 255)
                diff = -5;
            else if (timeCounter == 0)
                diff = 5;
            return timeCounter;
        }
    }
}
