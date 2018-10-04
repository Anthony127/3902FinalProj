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
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Replace("\\bin\\Windows\\x86\\Debug", "");
            MarioLevelLoader.Instance.LoadLevelFromFile(path + "\\Level\\Sprint3Level.xml");
            Mario.Instance.SetConditionState(new SmallMarioState(Mario.Instance));
            Mario.Instance.UnloadStarMario();
        }

    }
}
