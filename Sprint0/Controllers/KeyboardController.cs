using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.MarioMovementCommands;
using SuperPixelBrosGame.Commands;
using System.Collections.Generic;
using System.Diagnostics;

namespace SuperPixelBrosGame
{
    internal class KeyboardController : IController
    {
        private readonly SuperPixelBrosGame SuperPixelBrosGame;
        private Dictionary<string, ICommand> commandDictionary;
        private KeyboardState state;

        public KeyboardController(SuperPixelBrosGame SuperPixelBrosGame)
        {
            commandDictionary = new Dictionary<string, ICommand>();
            this.SuperPixelBrosGame = SuperPixelBrosGame;
        }

        public void RegisterCommands()
        {
            commandDictionary.Add(Keys.Q.ToString(), new QuitCommand(SuperPixelBrosGame));
            commandDictionary.Add(Keys.R.ToString(), new ResetSpritesCommand());
            commandDictionary.Add(Keys.A.ToString(), new LeftCommand());
            commandDictionary.Add(Keys.Left.ToString(), new LeftCommand());
            commandDictionary.Add(Keys.D.ToString(), new RightCommand());
            commandDictionary.Add(Keys.Right.ToString(), new RightCommand());
            commandDictionary.Add(Keys.W.ToString(), new UpCommand());
            commandDictionary.Add(Keys.Space.ToString(), new UpCommand());
            commandDictionary.Add(Keys.Up.ToString(), new UpCommand());
            commandDictionary.Add(Keys.S.ToString(), new DownCommand());
            commandDictionary.Add(Keys.Down.ToString(), new DownCommand());
            commandDictionary.Add(Keys.E.ToString(), new ThrowFireBallCommand());
        }

        public void Update()
        {
            ICommand command = null;
            state = Keyboard.GetState();
            if((state.IsKeyUp(Keys.Down) && state.IsKeyUp(Keys.S)) && (Mario.Instance.MovementState.MovementCode.Equals("RCRH")|| Mario.Instance.MovementState.MovementCode.Equals("LCRH")))
            {
                command = new UpCommand();
                command.Execute();
            }

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