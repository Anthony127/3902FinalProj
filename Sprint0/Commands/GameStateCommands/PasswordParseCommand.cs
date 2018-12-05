using SuperPixelBrosGame.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class PasswordParseCommand : ICommand
    {
        private PasswordInputController controller;

        public PasswordParseCommand(PasswordInputController controller)
        {
            this.controller = controller;
        }

        public void Execute()
        {
            PasswordUtility.Instance.parsePassword(controller.DynamicCode);
            controller.DynamicCode = "";


        }

    }
}
