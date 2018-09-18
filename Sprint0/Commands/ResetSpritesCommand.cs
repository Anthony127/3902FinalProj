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
            sprint0.BrickBlock.Reset();
            sprint0.QuestionBlock.Reset();
            sprint0.HiddenBlock.Reset();
        }

    }
}
