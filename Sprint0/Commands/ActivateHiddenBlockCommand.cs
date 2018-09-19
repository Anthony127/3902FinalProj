namespace Sprint0
{
    class ActivateHiddenBlockCommand : ICommand
    {
        private Sprint0 sprint0;

        public ActivateHiddenBlockCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.HiddenBlock.Activate();
        }
    }
}