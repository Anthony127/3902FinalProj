using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
    class PauseGameState : AbstractGameState, IGameState
    {
        private int pauseTimer;
        public PauseGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera) : base(game, controllerList, camera)
        {
            pauseTimer = 15;
            game.DelayInput(15);
            MediaPlayer.Stop();
        }

        public override void Update()
        {
            if (pauseTimer> 0)
            {
                pauseTimer--;
            }
            else
            {
                foreach(IController controller in controllerList)
                {
                    if (controller is PauseController)
                    {
                        controller.Update();
                    }

                }
            }
        }
    }
}
