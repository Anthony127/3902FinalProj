using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;

namespace SuperPixelBrosGame
{
    class ResetSpritesCommand : ICommand
    {
        private SuperPixelBrosGame SuperPixelBrosGame;

        public ResetSpritesCommand(SuperPixelBrosGame SuperPixelBrosGame)
        {
            this.SuperPixelBrosGame = SuperPixelBrosGame;
        }

        public void Execute()
        {
            SuperPixelBrosGame.ResetLevel();
        }

    }
}
