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
    internal class Controls
    {
        public static Header Game { get; set; }

        public static void AddOperationToClick(Button button, string operation)
        {
            switch (operation)
            {
                case "shop":
                    button.Click += ShopButtonClick;
                    break;
                case "play":
                    button.Click += PlayButtonClick;
                    break;
                case "quit":
                    button.Click += QuitButtonClick;
                    break;
                case "menu":
                    button.Click += MenuButtonClick;
                    break;
                case "shoot":
                    button.Click += ShootMode.Shoot;
                    break;
                case "reset":
                    button.Click += ClickResetOffset;
                    break;
                case "aimUp":
                    button.Click += ClickAimerUp;
                    break;
                case "aimDown":
                    button.Click += ClickAimerDown;
                    break;
                case "aimRight":
                    button.Click += ClickAimerRight;
                    break;
                case "aimLeft":
                    button.Click += ClickAimerLeft;
                    break;
                default: break;
            }
        }

        private static void MenuButtonClick(object sender, EventArgs e)
        {
            Main.state = GameState.Menu;
        }

        private static void PlayButtonClick(object sender, EventArgs e)
        {
            Levels.CreateLevel();
            Main.state = GameState.Game;
        }

        private static void ShopButtonClick(object sender, EventArgs e) => Main.state = GameState.Shop;

        private static void QuitButtonClick(object sender, EventArgs e) => Game.Exit();

        private static void ClickAimerUp(object sender, EventArgs e) => ShootMode.dy++;
        private static void ClickAimerDown(object sender, EventArgs e) => ShootMode.dy--;
        private static void ClickAimerRight(object sender, EventArgs e) => ShootMode.dx++;
        private static void ClickAimerLeft(object sender, EventArgs e) => ShootMode.dx--;
        private static void ClickResetOffset(object sender, EventArgs e)
        {
            ShootMode.dx = 0;
            ShootMode.dy = 0;
        }
    }
}
