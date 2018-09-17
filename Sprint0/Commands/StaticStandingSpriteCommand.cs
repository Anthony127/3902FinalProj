namespace Sprint0
{
    class StaticStandingSpriteCommand : ICommand
    {
        private Sprint0 sprint0;

        public StaticStandingSpriteCommand(Sprint0 sprint0) 
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.SetCurrentSprite(new StaticStandingSprite(sprint0.SpriteSheet));
        }

    }
}