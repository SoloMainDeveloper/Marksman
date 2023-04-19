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
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SplashScreen.Background = Content.Load<Texture2D>("Background");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            spriteBatch = new(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            var keyBoardState = Keyboard.GetState();
            switch (state)
            {
                case GameState.SplashScreen:
                    SplashScreen.Update();
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
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
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}