using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint0
{
    internal class KeyboardController : IController
    {
        private Sprint0 sprint0;
        private Dictionary<string, ICommand> commandDictionary;
        private KeyboardState state;

        public KeyboardController(Sprint0 sprint0)
        {
            commandDictionary = new Dictionary<string, ICommand>();
            this.sprint0 = sprint0;
        }

        public void RegisterCommand(string key, ICommand command)
        {
            commandDictionary.Add(key, command);
        }

        public void RegisterJoystick(Vector2 vector2, ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            ICommand command = null;
            state = Keyboard.GetState();
            foreach(Keys key in state.GetPressedKeys()) 
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