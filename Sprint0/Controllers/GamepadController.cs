using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;

namespace Sprint0
{
    class GamepadController : IController
    {
        private Sprint0 sprint0;
        private Dictionary<string, ICommand> commandDictionary;
        private GamePadState state;
        private List<Buttons> buttonList;
        private Dictionary<Vector2, IList<ICommand>> joystickDictionary;

        public GamepadController(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            commandDictionary = new Dictionary<string, ICommand>();
            joystickDictionary = new Dictionary<Vector2, IList<ICommand>>();
            buttonList = new List<Buttons>()
                {
                    {Buttons.A},
                    {Buttons.B},
                    {Buttons.Y},
                    {Buttons.X},
                    {Buttons.Start},
                };
        }

        public void RegisterCommands()
        {
            commandDictionary.Add(Buttons.Start.ToString(), new ResetSpritesCommand(sprint0));
            joystickDictionary.Add(NormalizeVector(new Vector2(System.Convert.ToSingle(-.5), 0)), new List<ICommand>() { { new LeftCommand() } });
            joystickDictionary.Add(NormalizeVector(new Vector2(System.Convert.ToSingle(.5), 0)), new List<ICommand>() { { new RightCommand() } });
            joystickDictionary.Add(NormalizeVector(new Vector2(0, System.Convert.ToSingle(.5))), new List<ICommand>() { { new UpCommand() } });
            joystickDictionary.Add(NormalizeVector(new Vector2(0, System.Convert.ToSingle(-.5))), new List<ICommand>() { { new DownCommand() } });

            joystickDictionary.Add(NormalizeVector(new Vector2(System.Convert.ToSingle(-.5), System.Convert.ToSingle(-.5))), new List<ICommand>() { { new DownCommand() }, { new LeftCommand() } });
            joystickDictionary.Add(NormalizeVector(new Vector2(System.Convert.ToSingle(.5), System.Convert.ToSingle(-.5))), new List<ICommand>() { { new DownCommand() }, { new RightCommand() } });
            joystickDictionary.Add(NormalizeVector(new Vector2(System.Convert.ToSingle(-.5), System.Convert.ToSingle(.5))), new List<ICommand>() { { new UpCommand() }, { new LeftCommand() } });
            joystickDictionary.Add(NormalizeVector(new Vector2(System.Convert.ToSingle(.5), System.Convert.ToSingle(.5))), new List<ICommand>() { { new UpCommand() }, { new RightCommand() } });
        }

        private Vector2 NormalizeVector(Vector2 target)
        {
            Vector2 normalizedVector = target;
       
            if (normalizedVector.X >= .01)
            {
                normalizedVector.X = (float).5;
            }
            else if (normalizedVector.X <= -.1)
            {
                normalizedVector.X = (float)-.5;
            }


            if (normalizedVector.Y >= .01)
            {
                normalizedVector.Y = (float).5;
            }
            else if (normalizedVector.Y <= -.1)
            {
                normalizedVector.Y = (float)-.5;
            }
            return normalizedVector;
        }

        public void Update()
        {
            ICommand command = null;
            IList<ICommand> commandList = null;
            state = GamePad.GetState(PlayerIndex.One);
            Vector2 thumbstick = NormalizeVector(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left);
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

            joystickDictionary.TryGetValue(thumbstick, out commandList);
            if(commandList != null)
            {
                foreach(ICommand commandMember in commandList)
                {
                    commandMember.Execute();
                }
            }
        }
    }
}