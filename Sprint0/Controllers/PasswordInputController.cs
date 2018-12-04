using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.MarioMovementCommands;
using SuperPixelBrosGame.Commands;
using SuperPixelBrosGame.Sprites;
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
            commandDictionary.Add(Keys.Enter.ToString(), new PasswordParseCommand(SuperPixelBrosGame, this));
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
                    //if (key is Keys.A)
                    //{
                    //    dynamicCode += "a";
                    //}

                    switch (key)
                    {
                        case Keys.A:
                            dynamicCode += "a";
                            break;
                        case Keys.B:
                            dynamicCode += "b";
                            break;
                        case Keys.C:
                            dynamicCode += "c";
                        case Keys.D:
                            dynamicCode += "d";
                            break;
                        case Keys.E:
                            dynamicCode += "e";
                            break;
                        case Keys.F:
                            dynamicCode += "f";
                            break;
                        case Keys.G:
                            dynamicCode += "g";
                            break;
                        case Keys.H:
                            dynamicCode += "h";
                            break;
                        case Keys.I:
                            dynamicCode += "i";
                            break;
                        case Keys.J:
                            dynamicCode += "j";
                            break;
                        case Keys.K:
                            dynamicCode += "k";
                            break;
                        case Keys.L:
                            dynamicCode += "l";
                            break;
                        case Keys.M:
                            dynamicCode += "m";
                            break;
                        case Keys.N:
                            dynamicCode += "n";
                            break;
                        case Keys.O:
                            dynamicCode += "o";
                            break;
                        case Keys.P:
                            dynamicCode += "p";
                            break;
                        case Keys.Q:
                            dynamicCode += "q";
                            break;
                        case Keys.R:
                            dynamicCode += "r";
                            break;
                        case Keys.S:
                            dynamicCode += "s";
                            break;
                        case Keys.T:
                            dynamicCode += "t";
                            break;
                        case Keys.U:
                            dynamicCode += "u";
                            break;
                        case Keys.V:
                            dynamicCode += "v";
                            break;
                        case Keys.W:
                            dynamicCode += "w";
                            break;
                        case Keys.X:
                            dynamicCode += "x";
                            break;
                        case Keys.Y:
                            dynamicCode += "y";
                            break;
                        case Keys.Z:
                            dynamicCode += "z";
                            break;

                    }



                    //Text Parsing
                    //Alex, the dynamicCode variable will print to screen whenever you change it. You don't have to pass it anywhere. It will do it automatically

                    //The enter key passes whatever dynamicCode currently is to something that updates Mario accordingly
                    
                }
            }
        }

    }
}