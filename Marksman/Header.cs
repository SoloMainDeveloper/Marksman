using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Marksman
{
    public class Header : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameState state = GameState.SplashScreen;


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
            SplashScreen.Background = Content.Load<Texture2D>("Background");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");

            var playButton = new Button(Content.Load<Texture2D>("Controls/PlayButton"), SplashScreen.Font)
            {
                Position = new Vector2(750, 350)
            };
            playButton.Click += PlayButtonClick;

            var quitButton = new Button(Content.Load<Texture2D>("Controls/ExitButton"), SplashScreen.Font)
            {
                Position = new Vector2(750, 650)
            };
            quitButton.Click += QuitButtonClick;

            var shopButton = new Button(Content.Load<Texture2D>("Controls/ShopButton"), SplashScreen.Font)
            {
                Position = new Vector2(750, 500)
            };
            shopButton.Click += ShopButtonClick;

            Menu.gameComponents = new List<Component>
            {
                playButton,
                shopButton,
                quitButton
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
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void PlayButtonClick(object sender, System.EventArgs e) => state = GameState.Game;

        private void ShopButtonClick(object sender, System.EventArgs e) => state = GameState.Shop;

        private void QuitButtonClick(object sender, System.EventArgs e) => Exit();
    }
}