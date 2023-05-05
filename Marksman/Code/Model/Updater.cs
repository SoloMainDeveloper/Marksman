using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marksman
{
    internal class Updater
    {
        public static void Update(GameTime gameTime, Header game)
        {
            switch (Main.state)
            {
                case GameState.SplashScreen:
                    SplashScreen.Update();
                    break;
                case GameState.Menu:
                    Menu.Update(gameTime);
                    break;
                case GameState.Game:
                    ShootMode.Update(gameTime);
                    break;
                case GameState.Levels:
                    Levels.Update(gameTime);
                    break;
                case GameState.Shop:
                    Levels.Update(gameTime);
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
        }
    }
}
