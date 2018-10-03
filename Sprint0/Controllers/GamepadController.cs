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
        private List<Vector2> joystickList;
        private Dictionary<Vector2, ICommand> joystickDictionary;

        public GamepadController(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            commandDictionary = new Dictionary<string, ICommand>();
            joystickDictionary = new Dictionary<Vector2, ICommand>();
            buttonList = new List<Buttons>()
                {
                    {Buttons.A},
                    {Buttons.B},
                    {Buttons.Y},
                    {Buttons.X},
                    {Buttons.Start},
                };
            joystickList = new List<Vector2>()
            {
                {new Vector2(-1,0) },
                {new Vector2(1,0) },
                {new Vector2(0,-1) },
                {new Vector2 (0,1)}
            };

        }

        public void RegisterCommand(string key, ICommand command)
        {
            commandDictionary.Add(key, command);
        }

        public void RegisterJoystick(Vector2 key, ICommand command)
        {
            joystickDictionary.Add(key, command);
        }

        public void Update()
        {
            ICommand command = null;
            state = GamePad.GetState(PlayerIndex.One);
            Vector2 thumbstick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            System.Console.Write(thumbstick.ToString());
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
            foreach(Vector2 vector in joystickList)
            {
                joystickDictionary.TryGetValue(thumbstick, out command);
                if(command != null)
                {
                    command.Execute();
                }
            }
        }
    }
}