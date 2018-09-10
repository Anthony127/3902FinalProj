using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

namespace Sprint0
{
    //This is the comment for Anthony required by Sprint 1.
    //And this is the comment for Jake Starrett for Sprint 1. And let me tell you, it's a fabulous comment. Love, Jake
    //And... This is a lame comment for Alexander Yehsakul for Sprint 1. Regards, Alex Y.

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Sprint0 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ArrayList controllerList;
        private ISprite CurrentSprite;
        public Texture2D SpriteSheet { get; private set; }

        public void SetCurrentSprite (ISprite newSprite) 
        {
            CurrentSprite = newSprite;
        }

        public void ExitGame()
        {
            Exit();
        }

        public Sprint0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamepadController(this));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteSheet = Content.Load<Texture2D>("Sprites/smb_luigi_sheet");
            CurrentSprite = new StaticStandingSprite(SpriteSheet);
            LoadKeyboardMappings();
            LoadControllerMappings();
        }

        protected void LoadKeyboardMappings ()
        {
            foreach (IController controller in controllerList)
            {
                if (controller is KeyboardController)
                {
                    controller.RegisterCommand(Keys.Q.ToString(), new QuitCommand(this));
                    controller.RegisterCommand(Keys.W.ToString(), new StaticStandingSpriteCommand(this));
                    controller.RegisterCommand(Keys.E.ToString(), new StaticAnimatedSpriteCommand(this));
                    controller.RegisterCommand(Keys.R.ToString(), new MovingVerticalSpriteCommand(this));
                    controller.RegisterCommand(Keys.T.ToString(), new MovingAnimatedSpriteCommand(this));
                }
            }
        }

        protected void LoadControllerMappings ()
        {
            foreach (IController controller in controllerList)
            {
                if (controller is GamepadController)
                {
                    controller.RegisterCommand(Buttons.Start.ToString(), new QuitCommand(this));
                    controller.RegisterCommand(Buttons.A.ToString(), new StaticStandingSpriteCommand(this));
                    controller.RegisterCommand(Buttons.B.ToString(), new StaticAnimatedSpriteCommand(this));
                    controller.RegisterCommand(Buttons.X.ToString(), new MovingVerticalSpriteCommand(this));
                    controller.RegisterCommand(Buttons.Y.ToString(), new MovingAnimatedSpriteCommand(this));
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            CurrentSprite.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            CurrentSprite.Draw(spriteBatch, new Vector2(400, 200));

            base.Draw(gameTime);
        }
    }
}
