using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Marksman
{
    public class Menu
    {
        public static List<Component> gameComponents { get; set; }
        public static Texture2D Background { get; set; }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var component in gameComponents)
                component.Draw(gameTime, spriteBatch);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (var component in gameComponents)
                component.Update(gameTime);
        }
    }
}