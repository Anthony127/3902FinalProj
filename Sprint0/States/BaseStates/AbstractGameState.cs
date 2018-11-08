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

namespace SuperPixelBrosGame
{
    abstract class AbstractGameState : IGameState
    {
        protected SuperPixelBrosGame game;
        protected ArrayList controllerList;
        protected ICamera camera;

        public AbstractGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera)
        {
            this.game = game;
            this.controllerList = controllerList;
            this.camera = camera;
        }

        public virtual void Draw(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);
            PlayerLevel.Instance.LevelDraw(camera);
        }

        public virtual void Update()
        {
            Console.WriteLine("Mario Location: X = " + Mario.Instance.Location.X + " Y = " + Mario.Instance.Location.Y);
            if (game.InputDelay <= 0)
            {
                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }
            }
            else
            {
                game.InputDelay--;
            }
            PlayerLevel.Instance.LevelUpdate(camera);

            camera.CameraUpdate();
        }
    }
}
