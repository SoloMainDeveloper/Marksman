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
        public static void LoadEverything(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            var font = Content.Load<SpriteFont>("SplashFont");
            SplashScreen.Background = Content.Load<Texture2D>("Background");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");

            var playButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/PlayButton"), font)
            { Position = new(750, 350) };
            var quitButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/QuitButton"), font)
            { Position = new(750, 650) };
            var shopButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/ShopButton"), font)
            { Position = new(750, 500) };
            Menu.gameComponents = new List<Component> { playButton, shopButton, quitButton };

            ShootMode.MainFont = font;
            ShootMode.NotebookFont = Content.Load<SpriteFont>("Assets/Fonts/NotebookFont");
            ShootMode.Aimer = Content.Load<Texture2D>("Assets/Aimer");
            ShootMode.Target = Content.Load<Texture2D>("Assets/Target");
            ShootMode.Background = Content.Load<Texture2D>("Assets/Grass");
            ShootMode.Notebook = Content.Load<Texture2D>("Assets/Notebook");
            ShootMode.BulletInfo = Content.Load<Texture2D>("Assets/BulletInfo");
            ShootMode.Shots = new Texture2D[6];
            for (var i = 1; i < 7; i++) ShootMode.Shots[i - 1] = Content.Load<Texture2D>("Assets/Shots/Shot" + i);

            var rightController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonRight"), font)
            { Position = new(1020, 650) };
            var leftController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonLeft"), font)
            { Position = new(820, 650) };
            var upController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonUp"), font)
            { Position = new(1110, 725) };
            var downController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonDown"), font)
            { Position = new(1110, 815) };
            var resetController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonReset"), font)
            { Position = new(705, 945) };
            var shootButton = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonShoot"), font)
            { Position = new(1120, 945) };
            var menuButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/ButtonMenu"), font)
            { Position = new(10, 13) };
            ShootMode.Buttons = new List<Button>
            {
                rightController, leftController, upController, downController,
                resetController, menuButton, shootButton
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
        }
    }
}
