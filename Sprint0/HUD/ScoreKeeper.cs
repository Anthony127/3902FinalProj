using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.HUD
{
    class ScoreKeeper
    {
        private int time;
        private int score;
        private int coins;
        private ScoreKeeper instance = new ScoreKeeper();
        public ScoreKeeper Instance()
        {
            return instance;
        }

        private ScoreKeeper()
        {
            time = 0;
            score = 0;
            coins = 0;
        }
    }
}
