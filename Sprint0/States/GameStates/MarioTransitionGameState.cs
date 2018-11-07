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
    class MarioTransitionGameState : AbstractGameState, IGameState
    {
        private int transitionTimeOut;
        public MarioTransitionGameState(SuperPixelBrosGame game, ArrayList controllerList, ICamera camera) : base(game, controllerList, camera)
        {
            transitionTimeOut = 80;
        }

        public override void Update()
        {
            if (transitionTimeOut > 0)
            {
                transitionTimeOut--;
            }
            else
            {
                game.GameState = new NormalGameState(game, controllerList, camera);
            }
        }
    }
}
