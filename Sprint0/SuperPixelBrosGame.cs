using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Commands;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections;
using System.Collections.Generic;

[assembly: CLSCompliant(true)]
namespace SuperPixelBrosGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SuperPixelBrosGame : Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ArrayList controllerList;
        private int levelTimeout = 150;
        private int transitionTimeout = 80;
        private ICamera camera;

        public int TransitionTimeout { get => transitionTimeout; }

        public void ExitGame()
        {
            Exit();
        }

        public SuperPixelBrosGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void TimeLevelOut()
        {
            levelTimeout--;
        }

        public void TransitionState()
        {
            transitionTimeout--;
        }

        public static void ResetLevel()
        {
            IPhysics physicsMario = (IPhysics)Mario.Instance;
            physicsMario.Velocity = new Vector2(0, 0);
            physicsMario.Friction = new Vector2(0, 0);
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug", "");
            MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\PhysicsTestLevel.xml");
            PlayerLevel.Instance.PlayerArray.Clear();
            PlayerLevel.Instance.PlayerArray.Add(Mario.Instance);
            Mario.Instance.ConditionState = new SmallMarioState(Mario.Instance);
            Mario.Instance.MovementState = new MarioRightIdleState(Mario.Instance);
            Mario.Instance.UnloadStarMario();


        }

        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamepadController());
            camera = new Camera(GraphicsDevice.Viewport);
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
            PlayerLevel.Instance.Background = background;
            PlayerLevel.Instance.Game = this;
            PlayerLevel.Instance.PlayerArray = new List<IMario> { Mario.Instance };
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug","");
            MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\PhysicsTestLevel.xml");

            PlayerLevel.Instance.LoadCollisions();
            foreach (IController controller in controllerList)
            {
                controller.RegisterCommands();
            }
            
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (transitionTimeout == 80)
            {
                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }

                PlayerLevel.Instance.LevelUpdate();

                if (levelTimeout <= 0)
                {
                    ResetLevel();
                    ResetLevel();
                    levelTimeout = 150;
                }
                else if (levelTimeout < 150)
                {
                    levelTimeout--;
                }
                camera.CameraUpdate();
            } 
            else if (transitionTimeout > 0)
            {
                transitionTimeout--;
            }
            else
            {
                transitionTimeout = 80;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            PlayerLevel.Instance.LevelDraw(camera);

            base.Draw(gameTime);
        }
    }
}
