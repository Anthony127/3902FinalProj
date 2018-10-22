using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;

namespace SuperPixelBrosGame
{
    class TimeLevelOutCommand : ICommand
    { 
        public void Execute()
        {
            PlayerLevel.Instance.TimeLevelOut();
        }
    }
}
