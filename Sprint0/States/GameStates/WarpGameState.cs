using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.GameStates
{
    class WarpGameState : AbstractGameState, IGameState
    {
        private int sinkTimeOut;
        private int riseTimeOut;
        private int loadTimeOut;
        private Vector2 location;
        private IMario mario;

        public WarpGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera, IMario mario, Vector2 location) : base(game, controllerList, camera)
        {
            this.mario = mario;
            this.location = location;
            sinkTimeOut = 60;
            riseTimeOut = 60;
            loadTimeOut = 60;
            mario.Idle();
        }

        public override void Update()
        {
            IPhysics marioPhysics = (IPhysics)mario;
            ICollidable marioCollision = (ICollidable)mario;
            if (sinkTimeOut > 0)
            {
                sinkTimeOut--;
                marioPhysics.Velocity = new Vector2(0, (float).75);
                mario.Update();
            }
            else if (sinkTimeOut == 0)
            {
                mario.Location = new Vector2(location.X + 10, location.Y + 40);
                camera.CameraUpdate();
                PlayerLevel.Instance.LevelUpdate(camera);
                mario.Location = new Vector2(location.X + 10, location.Y + 40);
                sinkTimeOut--;
            }
            else if (sinkTimeOut <= 0 && loadTimeOut > 0)
            {
                loadTimeOut--;
                Console.WriteLine(loadTimeOut);
            }
            else if (loadTimeOut <= 0 && riseTimeOut > 0)
            {
                riseTimeOut--;
                if (mario.Location.Y > (location.Y - marioCollision.Hitbox.Height))
                {
                    mario.Location = new Vector2(mario.Location.X, mario.Location.Y - 2);
                }

            }
            else
            {
                game.GameState = new NormalGameState(game, controllerList, camera);
            }
        }

        public override void Draw(GraphicsDevice graphicsDevice)
        {
            if (sinkTimeOut > 0)
            {
                base.Draw(graphicsDevice);
            }
            else if (loadTimeOut > 0)
            {
                graphicsDevice.Clear(Color.Black);
            }
            else
            {
                base.Draw(graphicsDevice);
            }
        }
    }
}
