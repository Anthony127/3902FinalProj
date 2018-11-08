using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.HUDComponents
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
            time = 400;
            score = 0;
            coins = 0;
        }

        public int GetTime()
        {
            return time;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetCoins()
        {
            return coins;
        }

        public void DecrementTime()
        {
            time--;
        }

        public void IncrementCoins()
        {
            coins++;
        }

        public void IncreaseScore(int amount)
        {
            score += amount;
        }
    }
}
