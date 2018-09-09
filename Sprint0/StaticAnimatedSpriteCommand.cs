namespace Sprint0
{
    class StaticAnimatedSpriteCommand : ICommand
    {

        private Sprint0 sprint0;

        public StaticAnimatedSpriteCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.SetCurrentSprite(new StaticAnimatedSprite(sprint0.SpriteSheet));
        }

    }
}