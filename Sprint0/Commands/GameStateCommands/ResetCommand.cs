using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;

namespace SuperPixelBrosGame
{
    class ResetSpritesCommand : ICommand
    {

        public ResetSpritesCommand()
        {
        }

        public void Execute()
        {
            SuperPixelBrosGame.ResetLevel();
        }

    }
}
