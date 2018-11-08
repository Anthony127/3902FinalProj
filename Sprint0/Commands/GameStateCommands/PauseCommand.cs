using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class PauseCommand : ICommand
    {
        private SuperPixelBrosGame SuperPixelBrosGame;

        public PauseCommand(SuperPixelBrosGame SuperPixelBrosGame)
        {
            this.SuperPixelBrosGame = SuperPixelBrosGame;
        }

        public void Execute()
        {
            SuperPixelBrosGame.TogglePause();
        }

    }
}
