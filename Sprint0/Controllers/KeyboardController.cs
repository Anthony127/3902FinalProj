using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint0
{
    internal class KeyboardController : IController
    {
        private Sprint0 sprint0;
        private Dictionary<string, ICommand> commandDictionary;
        private KeyboardState state;
        private Vector2 thumbstick;

        public KeyboardController(Sprint0 sprint0)
        {
            commandDictionary = new Dictionary<string, ICommand>();
            this.sprint0 = sprint0;
            thumbstick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
        }

        public void RegisterCommand(string key, ICommand command)
        {
            commandDictionary.Add(key, command);
        }

        public void RegisterJoystick(Vector2 vector2, IList<ICommand> commandList)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            ICommand command = null;
            state = Keyboard.GetState();
            thumbstick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            foreach (Keys key in state.GetPressedKeys()) 
            {
                commandDictionary.TryGetValue(key.ToString(), out command);
                if (command != null) 
                {
                    command.Execute();
                }
            }
            if (state.GetPressedKeys().Length == 0 && thumbstick.X == 0 && thumbstick.Y == 0)
            {
                command = new MarioIdleCommand();
                command.Execute();
            }
        }

    }
}