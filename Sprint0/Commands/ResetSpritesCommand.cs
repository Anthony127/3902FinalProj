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
            sprint0.BrickBlock = new BrickBlock();
            sprint0.QuestionBlock = new QuestionBlock();
            sprint0.HiddenBlock = new HiddenBlock();
            sprint0.Mario = new Mario();
        }

    }
}
