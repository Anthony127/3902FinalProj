namespace Sprint0
{
    class MovingVerticalSpriteCommand : ICommand
    {
        private Sprint0 sprint0;

        public MovingVerticalSpriteCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.SetCurrentSprite(new MovingVerticalSprite(sprint0.SpriteSheet));
        }
    }
}