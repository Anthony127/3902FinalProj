using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.Level;
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
        public IMario Mario { get; set; }
        public IBlock BrickBlock { get; set; }
        public IBlock QuestionBlock { get; set; }
        public IBlock HiddenBlock { get; set; }
        public ISprite FireFlower { get; private set; }
        public ISprite Coin { get; private set; }
        public ISprite SuperMushroom { get; private set; }
        public ISprite OneUpMushroom { get; private set; }
        public ISprite Star { get; private set; }
        public IEnemy Goomba { get; private set; }
        public IEnemy Koopa { get; private set; }
        public IBlock UnbreakableBlock { get; set; }
        public IBlock UsedBlock { get; set; }
        public IBlock GroundBlock { get; set; }
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

        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamepadController(this));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PlayerLevel.Instance.SetSpriteBatch(spriteBatch);
            PlayerSpriteFactory.Instance.LoadTextures(Content);
            EnemySpriteFactory.Instance.LoadTextures(Content);
            TerrainSpriteFactory.Instance.LoadTextures(Content);
            ItemSpriteFactory.Instance.LoadTextures(Content);

            Texture2D background = Content.Load<Texture2D>("Sprint3Background");
            PlayerLevel.Instance.SetBackground(background);
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug","");
            MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\Sprint3Level.xml");

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
                    controller.RegisterJoystick(new Vector2(-1,0), new LeftCommand(this));
                    controller.RegisterJoystick(new Vector2(1, 0), new RightCommand(this));
                    controller.RegisterJoystick(new Vector2(0, 1), new UpCommand(this));
                    controller.RegisterJoystick(new Vector2(0, -1), new DownCommand(this));
                }
            }
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            PlayerLevel.Instance.LevelUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            PlayerLevel.Instance.LevelDraw();

            base.Draw(gameTime);
        }
    }
}
