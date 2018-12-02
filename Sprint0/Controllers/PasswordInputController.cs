using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.MarioMovementCommands;
using SuperPixelBrosGame.Commands;
using System.Collections.Generic;
using System.Diagnostics;

namespace SuperPixelBrosGame
{
    public class PasswordInputController : IController
    {
        private readonly SuperPixelBrosGame SuperPixelBrosGame;
        private Dictionary<string, ICommand> commandDictionary;
        private KeyboardState state;
        private string dynamicCode = "";

        public string DynamicCode { get => dynamicCode; set => dynamicCode = value; }


        public PasswordInputController(SuperPixelBrosGame SuperPixelBrosGame)
        {
            commandDictionary = new Dictionary<string, ICommand>();
            this.SuperPixelBrosGame = SuperPixelBrosGame;
        }

        public void RegisterCommands()
        {
            commandDictionary.Add(Keys.Escape.ToString(), new CodeEntryCommand(SuperPixelBrosGame, this));
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
                    dynamicCode = "";
                }
                else
                {
                    //Text Parsing
                    //Alex, the dynamicCode variable will print to screen whenever you change it. You don't have to 
                }
            }
        }

    }
}