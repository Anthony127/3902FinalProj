using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    class GamepadController : IController
    {
        private Sprint0 sprint0;
        private Dictionary<string, ICommand> commandDictionary;
        private GamePadState state;
        private List<Buttons> buttonList;

        public GamepadController(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            commandDictionary = new Dictionary<string, ICommand>();
            buttonList = new List<Buttons>()
                {
                    {Buttons.A},
                    {Buttons.B},
                    {Buttons.Y},
                    {Buttons.X},
                    {Buttons.Start},
                };

        }

        public void RegisterCommand(string key, ICommand command)
        {
            commandDictionary.Add(key, command);
        }

        public void Update()
        {
            ICommand command = null;
            state = GamePad.GetState(PlayerIndex.One);
            foreach (Buttons button in buttonList)
            {
                if (state.IsButtonDown(button))
                {
                    commandDictionary.TryGetValue(button.ToString(), out command);
                    if (command != null)
                    {
                        command.Execute();
                    }
                }
            }
        }
    }
}