using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
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
        private ISprite currentSprite;

        public IBlockSprite BrickBlock { get; private set; }
        public IBlockSprite QuestionBlock { get; private set; }
        public IBlockSprite HiddenBlock { get; private set; }
        public Texture2D SpriteSheet { get; private set; }

        public void SetCurrentSprite (ISprite newSprite) 
        {
            currentSprite = newSprite;
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
            //PlayerSpriteFactory.Instance.LoadTextures(Content);
            //CurrentSprite = PlayerSpriteFactory.Instance.CreateSmallMarioSprite();
            //EnemySpriteFactory.Instance.LoadTextures(Content);
            //CurrentSprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
            TerrainSpriteFactory.Instance.LoadTextures(Content);
            BrickBlock = TerrainSpriteFactory.Instance.CreateBrickBlockSprite();
            QuestionBlock = TerrainSpriteFactory.Instance.CreateQuestionBlockSprite();
            HiddenBlock = TerrainSpriteFactory.Instance.CreateHiddenBlockSprite();
            ItemSpriteFactory.Instance.LoadTextures(Content);
            currentSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
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
                    controller.RegisterCommand(Keys.Z.ToString(), new ActivateQuestionBlockCommand(this));
                    controller.RegisterCommand(Keys.X.ToString(), new ActivateBrickBlockCommand(this));
                    controller.RegisterCommand(Keys.C.ToString(), new ActivateHiddenBlockCommand(this));
                    controller.RegisterCommand(Keys.R.ToString(), new ResetSpritesCommand(this));

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

            QuestionBlock.Update();
            BrickBlock.Update();
            HiddenBlock.Update();
            currentSprite.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentSprite.Draw(spriteBatch, new Vector2(500, 200));

            BrickBlock.Draw(spriteBatch, new Vector2(100, 200));
            QuestionBlock.Draw(spriteBatch, new Vector2(200, 200));
            HiddenBlock.Draw(spriteBatch, new Vector2(300, 200));

            base.Draw(gameTime);
        }
    }
}
