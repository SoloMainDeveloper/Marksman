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
                    SplashScreenUpdate();
                    break;
                case GameState.Menu:
                    MenuUpdate(gameTime);
                    break;
                case GameState.Game:
                    ShootModeUpdate(gameTime);
                    break;
                case GameState.Levels:
                    LevelsUpdate(gameTime);
                    break;
                case GameState.Shop:
                    ShopUpdate(gameTime);
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
        }

        private static void SplashScreenUpdate()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                Main.state = GameState.Menu;
            SplashScreen.timeCounter = (SplashScreen.timeCounter + SplashScreen.diff) % 256;
            if (SplashScreen.timeCounter == 255)
                SplashScreen.diff = -5;
            else if (SplashScreen.timeCounter == 0)
                SplashScreen.diff = 5;
            SplashScreen.color = Color.FromNonPremultiplied(0, 0, 0, SplashScreen.timeCounter);
        }

        private static void MenuUpdate(GameTime gameTime)
        {
            foreach (var component in Menu.gameComponents)
                component.Update(gameTime);
        }

        private static void ShootModeUpdate(GameTime gameTime)
        {
            foreach (var button in ShootMode.Buttons)
                button.Update(gameTime);
        }

        private static void LevelsUpdate(GameTime gameTime)
        {
            foreach (var button in Levels.levelButtons)
                button.Update(gameTime);
        }

        private static void ShopUpdate(GameTime gameTime)
        {

        }
    }
}
