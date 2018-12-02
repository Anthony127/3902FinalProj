using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class CodeEntryCommand : ICommand
    {
        private SuperPixelBrosGame SuperPixelBrosGame;
        private PasswordInputController controller;

        public CodeEntryCommand(SuperPixelBrosGame SuperPixelBrosGame, PasswordInputController controller)
        {
            this.SuperPixelBrosGame = SuperPixelBrosGame;
            this.controller = controller;
        }

        public void Execute()
        {
            SuperPixelBrosGame.ToggleCodeEntry();
            controller.DynamicCode = "";
        }

    }
}
