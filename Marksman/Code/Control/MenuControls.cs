//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace Marksman
//{
//    internal class MenuControls
//    {
//        public void AddOperationToClick(System.EventHandler click, string operation)
//        {
//            switch (operation)
//            {
//                case "shop":
//                    click += ShopButtonClick;
//                    break;
//                case "play":
//                    click += PlayButtonClick;
//                    break;
//                //case "quit":
//                //    click += QuitButtonClick;
//                    break;
//                default: break;
//            }
//        }

//        private void PlayButtonClick(object sender, System.EventArgs e)
//        {
//            Main.state = GameState.Game;
//            ShootMode.CreateLevel(150, 4, Direction.Left, 3);
//        }

//        private void ShopButtonClick(object sender, EventArgs e) => Main.state = GameState.Shop;

//        //private void QuitButtonClick(object sender, EventArgs e) => Exit();
//    }
//}
