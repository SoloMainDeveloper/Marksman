using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Marksman
{
    internal class Controls
    {
        public static Header Game { get; set; }

        public static void AddOperationToClick(Button button, string operation)
        {
            //button.Click += SoundClick;
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
                case "music":
                    button.Click += ClickNextSong;
                    break;
                case "loadLevel1":
                    button.Click += LoadLevel1;
                    break;
                case "loadLevel2":
                    button.Click += LoadLevel2;
                    break;
                case "loadLevel3":
                    button.Click += LoadLevel3;
                    break;
                case "loadLevel4":
                    button.Click += LoadLevel4;
                    break;
                case "loadLevel5":
                    button.Click += LoadLevel5;
                    break;
                case "cup":
                    button.Click += LoadCup;
                    break;
                case "menu2":
                    button.Click += Menu2ButtonClick;
                    break;
                case "sandButton":
                    button.Click += SandButtonClick;
                    break;
                case "forestButton":
                    button.Click += ForestButtonClick;
                    break;
                case "grassButton":
                    button.Click += GrassButtonClick;
                    break;
                default: break;
            }
        }

        private static void MenuButtonClick(object sender, EventArgs e) => Main.State = GameState.Menu;
        private static void Menu2ButtonClick(object sender, EventArgs e) => Main.State = GameState.Levels;
        private static void PlayButtonClick(object sender, EventArgs e) => Main.State = GameState.Levels;
        private static void ShopButtonClick(object sender, EventArgs e) => Main.State = GameState.Shop;
        private static void QuitButtonClick(object sender, EventArgs e) => Game.Exit();
        private static void SoundClick(object sender, EventArgs e) => MediaPlayer.Play(Textures.Switch);
        private static void ClickAimerUp(object sender, EventArgs e) => ShootMode.ChangeDy(1);
        private static void ClickAimerDown(object sender, EventArgs e) => ShootMode.ChangeDy(-1);
        private static void ClickAimerRight(object sender, EventArgs e) => ShootMode.ChangeDx(1);
        private static void ClickAimerLeft(object sender, EventArgs e) => ShootMode.ChangeDx(-1);
        private static void ClickResetOffset(object sender, EventArgs e) => ShootMode.ResetDxDy();
        private static void ClickNextSong(object sender, EventArgs e) => SoundManager.PlayNextSong();

        private static void GrassButtonClick(object sender, EventArgs e) => Textures.CurrentBackground = Textures.ShootBackground;
        private static void ForestButtonClick(object sender, EventArgs e)
        {
            if (Main.HasForest)
                Textures.CurrentBackground = Textures.Forest;
            else if (Main.Money > 0)
            {
                Main.SpendMoney();
                Main.HasForest = true;
                Textures.CurrentBackground = Textures.Forest;
            }
        }

        private static void SandButtonClick(object sender, EventArgs e)
        {
            if (Main.HasSand)
                Textures.CurrentBackground = Textures.Sand;
            else if (Main.Money > 0)
            {
                Main.SpendMoney();
                Main.HasSand = true;
                Textures.CurrentBackground = Textures.Sand;
            }
        }

        //cringe, dont check
        private static void LoadLevel1(object sender, EventArgs e)
        {
            Main.Level = 1;
            Levels.CreateLevel();
            Main.State = GameState.Game;
        }
        private static void LoadLevel2(object sender, EventArgs e)
        {
            Main.Level = 2;
            Levels.CreateLevel();
            Main.State = GameState.Game;
        }
        private static void LoadLevel3(object sender, EventArgs e)
        {
            Main.Level = 3;
            Levels.CreateLevel();
            Main.State = GameState.Game;
        }
        private static void LoadLevel4(object sender, EventArgs e)
        {
            Main.Level = 4;
            Levels.CreateLevel();
            Main.State = GameState.Game;
        }
        private static void LoadLevel5(object sender, EventArgs e)
        {
            Main.Level = 5;
            Levels.CreateLevel();
            Main.State = GameState.Game;
        }
        private static void LoadCup(object sender, EventArgs e)
        {
            Main.Level = 6;
            Levels.CreateLevel();
            Main.State = GameState.Game;
        }
    }
}
