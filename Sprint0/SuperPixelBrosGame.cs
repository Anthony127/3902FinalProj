﻿using Microsoft.Xna.Framework;
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

namespace SuperPixelBrosGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SuperPixelBrosGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ArrayList controllerList;
        int levelTimeout = 150;
        public Texture2D SpriteSheet { get; private set; }
        private Camera camera;

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

        public void ResetLevel()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug", "");
            //MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\Sprint3Level.xml");
            MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\PhysicsTestLevel.xml");
            PlayerLevel.Instance.playerArray.Clear();
            PlayerLevel.Instance.playerArray.Add(Mario.Instance);
            Mario.Instance.SetConditionState(new SmallMarioState(Mario.Instance));
            Mario.Instance.SetMovementState(new MarioRightIdleState(Mario.Instance));
            Mario.Instance.UnloadStarMario();

            IPhysics physicsMario = (IPhysics)Mario.Instance;
            physicsMario.Velocity = new Vector2(0, 0);
            physicsMario.Friction = new Vector2(0, 0);
        }

        protected override void Initialize()
        {
            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new GamepadController(this));
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
            PlayerLevel.Instance.SetBackground(background);
            PlayerLevel.Instance.SetGame(this);
            PlayerLevel.Instance.SetPlayerArray(new List<IMario> { Mario.Instance });
            String path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug","");
            //MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\Sprint3Level.xml");
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
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            PlayerLevel.Instance.LevelUpdate();
            base.Update(gameTime);
            Console.WriteLine("LevelTimeOut = " + levelTimeout);
            if (levelTimeout == 0)
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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            PlayerLevel.Instance.LevelDraw(camera);

            base.Draw(gameTime);
        }
    }
}
