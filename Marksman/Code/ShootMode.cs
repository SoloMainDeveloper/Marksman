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
        public static List<Texture2D> Shots { get; set; }
        public static List<Button> Buttons { get; set; }
        
        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var posXtarget = 960 - Target.Width / 2;
            var posXaimer = 960 - Aimer.Width / 2;
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.Draw(Target, new Rectangle(posXtarget, 10, Target.Width, Target.Height), Color.White);
            spriteBatch.Draw(Aimer, new Rectangle(posXaimer, 1080 - Aimer.Height, Aimer.Width, Aimer.Height), Color.White);
            foreach (var button in Buttons)
                button.Draw(gameTime, spriteBatch);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var button in Buttons)
                button.Update(gameTime);
        }
    }
}
