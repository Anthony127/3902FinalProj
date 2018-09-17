namespace Sprint0
{
    class ActivateQuestionBlockCommand : ICommand
    {
        private Sprint0 sprint0;

        public ActivateQuestionBlockCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.QuestionBlock.Activate();
        }
    }
}
