namespace Sprint0
{
    internal class ActivateBrickBlockCommand : ICommand
    {
        private Sprint0 sprint0;

        public ActivateBrickBlockCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.BrickBlock.Activate();
        }
    }
}