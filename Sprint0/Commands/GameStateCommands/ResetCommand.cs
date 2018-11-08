using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;

namespace SuperPixelBrosGame
{
    class ResetSpritesCommand : ICommand
    {
        private SuperPixelBrosGame game;

        public ResetSpritesCommand(SuperPixelBrosGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.ResetLevel();
        }

    }
}
