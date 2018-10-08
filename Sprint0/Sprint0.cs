using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Interfaces;
using Sprint0.Level;
using Sprint0.States.Mario.Condition;
using System;
using System.Collections;
using System.Collections.Generic;

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

        public void ResetLevel()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug", "");
            MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\Sprint3Level.xml");
            Mario.Instance.SetConditionState(new SmallMarioState(Mario.Instance));
            Mario.Instance.UnloadStarMario();
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

            PlayerLevel.Instance.LoadCollisions();
            LoadKeyboardMappings();
            LoadControllerMappings();
        }

        protected void LoadKeyboardMappings ()
        {
            foreach (IController controller in controllerList)
            {
                    controller.RegisterCommand(Keys.Q.ToString(), new QuitCommand(this));
                    controller.RegisterCommand(Keys.R.ToString(), new ResetSpritesCommand(this));
                    controller.RegisterCommand(Keys.A.ToString(), new LeftCommand());
                    controller.RegisterCommand(Keys.Left.ToString(), new LeftCommand());
                    controller.RegisterCommand(Keys.D.ToString(), new RightCommand());
                    controller.RegisterCommand(Keys.Right.ToString(), new RightCommand());
                    controller.RegisterCommand(Keys.W.ToString(), new UpCommand());
                    controller.RegisterCommand(Keys.Up.ToString(), new UpCommand());
                    controller.RegisterCommand(Keys.S.ToString(), new DownCommand());
                    controller.RegisterCommand(Keys.Down.ToString(), new DownCommand());
            }
        }

        protected void LoadControllerMappings ()
        {
            foreach (IController controller in controllerList)
            {
                    controller.RegisterJoystick(new Vector2(System.Convert.ToSingle(-.5), 0), new List<ICommand>() { { new LeftCommand() } });
                    controller.RegisterJoystick(new Vector2(System.Convert.ToSingle(.5), 0), new List<ICommand>() { { new RightCommand() } });
                    controller.RegisterJoystick(new Vector2(0, System.Convert.ToSingle(.5)), new List<ICommand>() { { new UpCommand() } });
                    controller.RegisterJoystick(new Vector2(0, System.Convert.ToSingle(-.5)), new List<ICommand>() { { new DownCommand() } });

                    controller.RegisterJoystick(new Vector2(System.Convert.ToSingle(-.5), System.Convert.ToSingle(-.5)), new List<ICommand>() { { new DownCommand()},{ new LeftCommand() } });
                    controller.RegisterJoystick(new Vector2(System.Convert.ToSingle(.5), System.Convert.ToSingle(-.5)), new List<ICommand>() { { new DownCommand() }, { new RightCommand() } });
                    controller.RegisterJoystick(new Vector2(System.Convert.ToSingle(-.5), System.Convert.ToSingle(.5)), new List<ICommand>() { { new UpCommand() }, { new LeftCommand() } });
                    controller.RegisterJoystick(new Vector2(System.Convert.ToSingle(.5), System.Convert.ToSingle(.5)), new List<ICommand>() { { new UpCommand() }, { new RightCommand() } });
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
