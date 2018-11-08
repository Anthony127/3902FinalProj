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
        private static ScoreKeeper instance = new ScoreKeeper();

        public static ScoreKeeper Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private ScoreKeeper()
        {
            time = 24000;
            score = 0;
            coins = 0;
        }

        public int GetTime()
        {
            return time / 60 + 1;
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
