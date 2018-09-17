namespace Sprint0
{
    class MovingAnimatedSpriteCommand : ICommand
    {
        private Sprint0 sprint0;

        public MovingAnimatedSpriteCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.SetCurrentSprite(new MovingAnimatedSprite(sprint0.SpriteSheet));
        }

    }
}