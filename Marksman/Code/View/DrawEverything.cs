//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

//namespace Marksman
//{
//    internal class DrawEverything
//    {
//        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
//        {
//            switch (Main.state)
//            {
//                case GameState.SplashScreen:
//                    SplashScreen.Draw(spriteBatch);
//                    break;
//                case GameState.Menu:
//                    Menu.Draw(gameTime, spriteBatch);
//                    break;
//                case GameState.Game:
//                    ShootMode.Draw(gameTime, spriteBatch);
//                    break;
//                case GameState.Shop:
//                    Shop.Draw(gameTime, spriteBatch);
//                    break;
//            }
//        }
//    }
//}
