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
            var menuButton2 = new Button(Textures.MenuButton, font)
            { Position = new(10, 13) };
            var musicButton = new Button(Textures.MusicButton, font)
            {
                Position = new(115, 13)
            };
            ShootMode.Buttons = new List<Button>
            {
                rightController, leftController, upController, downController,
                resetController, menuButton2, shootButton, musicButton
            };

            var buttonLevel1 = new Button(Textures.Level, font)
            { Position = new(150, 200) };
            var buttonLevel2 = new Button(Textures.Level, font)
            { Position = new(250, 300) };
            var buttonLevel3 = new Button(Textures.Level, font)
            { Position = new(150, 400) };
            var buttonLevel4 = new Button(Textures.Level, font)
            { Position = new(250, 500) };
            var buttonLevel5 = new Button(Textures.Level, font)
            { Position = new(150, 600) };
            var cup = new Button(Textures.Cup, font)
            { Position = new(150, 700) };
            Levels.LevelButtons = new List<Button>
            {
                buttonLevel1, buttonLevel2, buttonLevel3, buttonLevel4,
                buttonLevel5, cup, musicButton, menuButton
            };
            var grassButton = new Button(Textures.ShootBackgroundButton, font)
            {
                Position = new(200, 200)
            };
            var forestButton = new Button(Textures.ForestButton, font)
            {
                Position = new(200, 450)
            };
            var sandButton = new Button(Textures.SandButton, font)
            {
                Position = new(200, 700)
            };
            Shop.Options = new List<Button>
            {
                musicButton, menuButton, forestButton, sandButton, grassButton
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
            Controls.AddOperationToClick(buttonLevel2, "loadLevel2");
            Controls.AddOperationToClick(buttonLevel3, "loadLevel3");
            Controls.AddOperationToClick(buttonLevel4, "loadLevel4");
            Controls.AddOperationToClick(buttonLevel5, "loadLevel5");
            Controls.AddOperationToClick(cup, "cup");
            Controls.AddOperationToClick(menuButton2, "menu2");
            Controls.AddOperationToClick(sandButton, "sandButton");
            Controls.AddOperationToClick(forestButton, "forestButton");
            Controls.AddOperationToClick(grassButton, "grassButton");
        }
    }
}
