using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marksman
{
    internal class Loader
    {
        public static void LoadEverything()
        {
            var Content = Main.Content;
            var font = Textures.FontHead;

            var playButton = new Button(Textures.PlayButton, font)
            { Position = new(1470, 550) };
            var shopButton = new Button(Textures.ShopButton, font)
            { Position = new(1470, 700) };
            var quitButton = new Button(Textures.QuitButton, font)
            { Position = new(1470, 850) };
            Menu.GameComponents = new List<Component> { playButton, shopButton, quitButton };

            for (var i = 1; i < 7; i++) Textures.Shots[i - 1] = Content.Load<Texture2D>("Assets/Shots/Shot" + i);

            var rightController = new Button(Textures.RightController, font)
            { Position = new(1020, 650) };
            var leftController = new Button(Textures.LeftController, font)
            { Position = new(820, 650) };
            var upController = new Button(Textures.UpController, font)
            { Position = new(1110, 725) };
            var downController = new Button(Textures.DownController, font)
            { Position = new(1110, 815) };
            var resetController = new Button(Textures.ResetButton, font)
            { Position = new(705, 945) };
            var shootButton = new Button(Textures.ShootButton, font)
            { Position = new(1120, 945) };
            var menuButton = new Button(Textures.MenuButton, font)
            { Position = new(10, 13) };
            var musicButton = new Button(Textures.MusicButton, font)
            {
                Position = new(115, 13)
            };
            ShootMode.Buttons = new List<Button>
            {
                rightController, leftController, upController, downController,
                resetController, menuButton, shootButton, musicButton
            };

            var buttonLevel1 = new Button(Textures.PlayButton, font)
            { Position = new(15, 200) };
            Levels.LevelButtons = new List<Button>
            {
                buttonLevel1, musicButton, menuButton
            };

            Controls.AddOperationToClick(playButton, "play");
            Controls.AddOperationToClick(quitButton, "quit");
            Controls.AddOperationToClick(shopButton, "shop");
            Controls.AddOperationToClick(menuButton, "menu");
            Controls.AddOperationToClick(resetController, "reset");
            Controls.AddOperationToClick(rightController, "aimRight");
            Controls.AddOperationToClick(leftController, "aimLeft");
            Controls.AddOperationToClick(upController, "aimUp");
            Controls.AddOperationToClick(downController, "aimDown");
            Controls.AddOperationToClick(shootButton, "shoot");
            Controls.AddOperationToClick(musicButton, "music");
            Controls.AddOperationToClick(buttonLevel1, "loadLevel1");
        }
    }
}
