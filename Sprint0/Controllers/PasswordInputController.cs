using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.MarioMovementCommands;
using SuperPixelBrosGame.Commands;
using SuperPixelBrosGame.Sprites;
using SuperPixelBrosGame.States.GameStates;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace SuperPixelBrosGame
{
    public class PasswordInputController : IController
    {
        private readonly SuperPixelBrosGame SuperPixelBrosGame;
        private StringBuilder stringBuilder = new StringBuilder("", 13);
        private int keyTimer = 10;
        private TextInfo ti = new CultureInfo("en-US", false).TextInfo;
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
            commandDictionary.Add(Keys.Enter.ToString(), new PasswordParseCommand(SuperPixelBrosGame, this));
        }

        public void Update()
        {
            ICommand command = null;
            state = Keyboard.GetState();
            if (keyTimer > 0)
            {
                keyTimer--;
            }

            foreach (Keys key in state.GetPressedKeys())
            {
                commandDictionary.TryGetValue(key.ToString(), out command);
                if (command != null)
                {
                    if ((key == Keys.Enter && SuperPixelBrosGame.GameState is CodeEntryGameState || key == Keys.Escape) && keyTimer == 0)
                    {
                        command.Execute();
                        stringBuilder.Clear();
                        keyTimer = 10;
                    }
                }
                else if (SuperPixelBrosGame.GameState is CodeEntryGameState)
                {
                    if (keyTimer == 0)
                    {
                        if (key == Keys.Delete || key == Keys.Back)
                        {
                            stringBuilder.Remove(stringBuilder.Length - 1, 1);
                            dynamicCode = stringBuilder.ToString();
                            dynamicCode = dynamicCode.ToLower();
                            dynamicCode = ti.ToTitleCase(dynamicCode);
                        }
                        else
                        {
                            stringBuilder.Append(key.ToString());
                            dynamicCode = stringBuilder.ToString();
                            dynamicCode = dynamicCode.ToLower();
                            dynamicCode = ti.ToTitleCase(dynamicCode);
                        }
                        keyTimer = 10;
                    }

                }
            }
        }

    }
}