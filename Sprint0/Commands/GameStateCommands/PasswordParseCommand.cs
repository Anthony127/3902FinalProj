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
        private SuperPixelBrosGame SuperPixelBrosGame;
        private PasswordInputController controller;

        public PasswordParseCommand(SuperPixelBrosGame SuperPixelBrosGame, PasswordInputController controller)
        {
            this.SuperPixelBrosGame = SuperPixelBrosGame;
            this.controller = controller;
        }

        public void Execute()
        {
            SpriteUtility.Instance.parsePassword(controller.DynamicCode);
            controller.DynamicCode = "";

        }

    }
}
