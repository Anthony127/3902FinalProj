using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.MarioMovementCommands;
using SuperPixelBrosGame.Commands;
using System.Collections.Generic;
using System.Diagnostics;

namespace SuperPixelBrosGame
{
    class PauseController : IController
    {
        private readonly SuperPixelBrosGame SuperPixelBrosGame;
        private Dictionary<string, ICommand> commandDictionary;
        private KeyboardState state;

        public PauseController(SuperPixelBrosGame SuperPixelBrosGame)
        {
            commandDictionary = new Dictionary<string, ICommand>();
            this.SuperPixelBrosGame = SuperPixelBrosGame;
        }

        public void RegisterCommands()
        {
            commandDictionary.Add(Keys.Q.ToString(), new QuitCommand(SuperPixelBrosGame));
            commandDictionary.Add(Keys.R.ToString(), new ResetSpritesCommand());
            commandDictionary.Add(Keys.P.ToString(), new PauseCommand(SuperPixelBrosGame));
        }

        public void Update()
        {
            ICommand command = null;
            state = Keyboard.GetState();

            foreach (Keys key in state.GetPressedKeys())
            {
                commandDictionary.TryGetValue(key.ToString(), out command);
                if (command != null)
                {
                    command.Execute();
                }
            }
        }

    }
}