using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class QuitCommand : ICommand
    {
        private SuperPixelBrosGame SuperPixelBrosGame;

        public QuitCommand(SuperPixelBrosGame SuperPixelBrosGame)
        {
            this.SuperPixelBrosGame = SuperPixelBrosGame;
        }

        public void Execute()
        {
            SuperPixelBrosGame.ExitGame();
        }

    }
}
