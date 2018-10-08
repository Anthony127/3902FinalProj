using Sprint0.Level;
using Sprint0.States.Mario.Condition;

namespace Sprint0
{
    class ResetSpritesCommand : ICommand
    {
        private Sprint0 sprint0;

        public ResetSpritesCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.ResetLevel();
        }

    }
}
