using SuperPixelBrosGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.MarioMovementCommands
{
    class ThrowFireBallCommand : ICommand
    {
        public void Execute()
        {
            Mario.Instance.ThrowFireBall();
            Mario.Instance.Run();
        }
    }
}
