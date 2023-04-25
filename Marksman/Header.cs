using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marksman
{
    public class Header : Game
    {
        public int Level = 1;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameState state = GameState.SplashScreen;
        private SpriteFont font;

        public Header()
        {
            graphics = new(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("SplashFont");
            SplashScreen.Background = Content.Load<Texture2D>("Background");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");

            var playButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/PlayButton"), font)
            { Position = new(750, 350) };
            playButton.Click += PlayButtonClick;

            var quitButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/QuitButton"), font)
            { Position = new(750, 650) };
            quitButton.Click += QuitButtonClick;

            var shopButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/ShopButton"), font)
            { Position = new(750, 500) };
            shopButton.Click += ShopButtonClick;

            Menu.gameComponents = new List<Component>
            {
                playButton, shopButton, quitButton
            };

            ShootMode.Font = font;
            ShootMode.Aimer = Content.Load<Texture2D>("Assets/Aimer");
            ShootMode.Target = Content.Load<Texture2D>("Assets/Target");
            ShootMode.Background = Content.Load<Texture2D>("Assets/Grass");
            ShootMode.Shots = new Texture2D[6];
            for (var i = 1; i < 7; i++)
                ShootMode.Shots[i - 1] = Content.Load<Texture2D>("Assets/Shots/Shot" + i);

            var rightController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonRight"), font)
            { Position = new(1020, 650) };
            rightController.Click += ShootMode.ClickAimerRight;

            var leftController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonLeft"), font)
            { Position = new(820, 650) };
            leftController.Click += ShootMode.ClickAimerLeft;

            var upController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonUp"), font)
            { Position = new(1110, 725) };
            upController.Click += ShootMode.ClickAimerUp;

            var downController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonDown"), font)
            { Position = new(1110, 815) };
            downController.Click += ShootMode.ClickAimerDown;

            var resetController = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonReset"), font)
            {
                Position = new(705, 945)
            };
            resetController.Click += ShootMode.ClickResetOffset;

            var shootButton = new Button(Content.Load<Texture2D>("Assets/GunControls/ButtonShoot"), font)
            {
                Position = new(1120, 945)
            };
            shootButton.Click += ShootMode.Shoot;

            var menuButton = new Button(Content.Load<Texture2D>("Assets/MenuControls/ButtonMenu"), font)
            {
                Position = new(10, 13)
            };
            menuButton.Click += MenuButtonClick;

            ShootMode.Buttons = new List<Button>
            {
                rightController, leftController, upController, downController,
                resetController, menuButton, shootButton
            };

            spriteBatch = new(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            var keyBoardState = Keyboard.GetState();
            switch (state)
            {
                case GameState.SplashScreen:
                    if (keyBoardState.IsKeyDown(Keys.Enter))
                        state = GameState.Menu;
                    SplashScreen.Update();
                    break;
                case GameState.Menu:
                    Menu.Update(gameTime);
                    break;
                case GameState.Game:
                    ShootMode.Update(gameTime);
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyBoardState.IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (state)
            {
                case GameState.SplashScreen:
                    SplashScreen.Draw(spriteBatch);
                    break;
                case GameState.Menu:
                    Menu.Draw(gameTime, spriteBatch);
                    break;
                case GameState.Game:
                    ShootMode.Draw(gameTime, spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void PlayButtonClick(object sender, System.EventArgs e)
        {
            state = GameState.Game;
            ShootMode.CreateLevel(150, 4, Direction.Left, 3);
        }

        private void ShopButtonClick(object sender, System.EventArgs e) => state = GameState.Shop;

        private void MenuButtonClick(object sender, System.EventArgs e) => state = GameState.Menu;

        private void QuitButtonClick(object sender, System.EventArgs e) => Exit();
    }
}