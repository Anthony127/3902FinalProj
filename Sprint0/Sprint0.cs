using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
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
        public IMarioSprite Mario { get; set; }
        public IBlockSprite BrickBlock { get; private set; }
        public IBlockSprite QuestionBlock { get; private set; }
        public IBlockSprite HiddenBlock { get; private set; }
        public ISprite FireFlower { get; private set; }
        public ISprite Coin { get; private set; }
        public ISprite SuperMushroom { get; private set; }
        public ISprite OneUpMushroom { get; private set; }
        public ISprite Star { get; private set; }
        public ISprite Goomba { get; private set; }
        public ISprite Koopa { get; private set; }
        public ISprite UnbreakableBlock { get; private set; }
        public ISprite UsedBlock { get; private set; }
        public ISprite GroundBlock { get; private set; }
        public ISprite Pipe { get; private set; }
        public Texture2D SpriteSheet { get; private set; }

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
            EnemySpriteFactory.Instance.LoadTextures(Content);
            TerrainSpriteFactory.Instance.LoadTextures(Content);
            ItemSpriteFactory.Instance.LoadTextures(Content);

            Mario = PlayerSpriteFactory.Instance.CreateMarioSprite();

            Goomba = EnemySpriteFactory.Instance.CreateGoombaSprite();
            Koopa = EnemySpriteFactory.Instance.CreateKoopaSprite();

            UnbreakableBlock = TerrainSpriteFactory.Instance.CreateUnbreakableBlockSprite();
            UsedBlock = TerrainSpriteFactory.Instance.CreateUsedBlockSprite();
            GroundBlock = TerrainSpriteFactory.Instance.CreateGroundBlockSprite();
            BrickBlock = TerrainSpriteFactory.Instance.CreateBrickBlockSprite();
            QuestionBlock = TerrainSpriteFactory.Instance.CreateQuestionBlockSprite();
            HiddenBlock = TerrainSpriteFactory.Instance.CreateHiddenBlockSprite();
            Pipe = TerrainSpriteFactory.Instance.CreatePipeSprite();

            FireFlower = ItemSpriteFactory.Instance.CreateFireFlowerSprite();
            Coin = ItemSpriteFactory.Instance.CreateCoinSprite();
            SuperMushroom = ItemSpriteFactory.Instance.CreateSuperMushroomSprite();
            OneUpMushroom = ItemSpriteFactory.Instance.CreateOneUpMushroomSprite();
            Star = ItemSpriteFactory.Instance.CreateStarSprite();

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
                    controller.RegisterCommand(Keys.R.ToString(), new ResetSpritesCommand(this));
                    controller.RegisterCommand(Keys.Z.ToString(), new ActivateQuestionBlockCommand(this));
                    controller.RegisterCommand(Keys.X.ToString(), new ActivateBrickBlockCommand(this));
                    controller.RegisterCommand(Keys.C.ToString(), new ActivateHiddenBlockCommand(this));
                    controller.RegisterCommand(Keys.Y.ToString(), new SmallMarioCommand(this));
                    controller.RegisterCommand(Keys.U.ToString(), new BigMarioCommand(this));
                    controller.RegisterCommand(Keys.I.ToString(), new FireMarioCommand(this));
                    controller.RegisterCommand(Keys.O.ToString(), new DeadMarioCommand(this));
                    controller.RegisterCommand(Keys.A.ToString(), new LeftCommand(this));
                    controller.RegisterCommand(Keys.Left.ToString(), new LeftCommand(this));
                    controller.RegisterCommand(Keys.D.ToString(), new RightCommand(this));
                    controller.RegisterCommand(Keys.Right.ToString(), new RightCommand(this));
                    controller.RegisterCommand(Keys.W.ToString(), new UpCommand(this));
                    controller.RegisterCommand(Keys.Up.ToString(), new UpCommand(this));
                    controller.RegisterCommand(Keys.S.ToString(), new DownCommand(this));
                    controller.RegisterCommand(Keys.Down.ToString(), new DownCommand(this));

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
            FireFlower.Update();
            Coin.Update();
            SuperMushroom.Update();
            OneUpMushroom.Update();
            Star.Update();
            Goomba.Update();
            Koopa.Update();
            UnbreakableBlock.Update();
            UsedBlock.Update();
            GroundBlock.Update();
            Pipe.Update();
            QuestionBlock.Update();
            BrickBlock.Update();
            HiddenBlock.Update();
            Mario.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            int counter = 50;

            Mario.Draw(spriteBatch, new Vector2(500, 500));

            FireFlower.Draw(spriteBatch, new Vector2(counter += 50, 100));
            Coin.Draw(spriteBatch, new Vector2(counter += 50, 100));
            SuperMushroom.Draw(spriteBatch, new Vector2(counter += 50, 100));
            OneUpMushroom.Draw(spriteBatch, new Vector2(counter += 50, 100));
            Star.Draw(spriteBatch, new Vector2(counter += 50, 100));
            Goomba.Draw(spriteBatch, new Vector2(counter += 50, 100));
            Koopa.Draw(spriteBatch, new Vector2(counter += 50, 100));

            counter = 50;

            HiddenBlock.Draw(spriteBatch, new Vector2(counter += 50, 300));
            UnbreakableBlock.Draw(spriteBatch, new Vector2(counter += 50, 300));
            UsedBlock.Draw(spriteBatch, new Vector2(counter += 50, 300));
            QuestionBlock.Draw(spriteBatch, new Vector2(counter += 50, 300));
            BrickBlock.Draw(spriteBatch, new Vector2(counter += 50, 300));
            GroundBlock.Draw(spriteBatch, new Vector2(counter += 50, 300));
            Pipe.Draw(spriteBatch, new Vector2(counter += 50, 300));

            base.Draw(gameTime);
        }
    }
}
