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
        private int lives;
        private int multiplier;
        private int amount;
        private static ScoreKeeper instance = new ScoreKeeper();

        public int Time { get => time / 30 + 1; }
        public int Score { get => score; }
        public int Coins { get => coins;}
        public int Lives { get => lives; }


        public static ScoreKeeper Instance
        {
            get
            {
                return instance;
            }
        }

        private ScoreKeeper()
        {
            time = 12000;
            score = 0;
            coins = 0;
            lives = 3;
            multiplier = 1;
            amount = 100;
        }

        public void IncrementLives()
        {
            lives++;
        }
        public void DecrementLives()
        {
            lives--;
        }
        public void IncMultiplier()
        {
            multiplier++;
        }
        public void ResetMultiplier()
        {
            multiplier = 1;
        }

        public void DecrementTime()
        {
            time--;
        }

        public void IncrementCoins()
        {
            if (coins == 99)
            {
                coins = 0;
            }
            else {
                coins++;
                score += 100;
            }
        }

        public int IncreaseScore()
        {
            score += amount * multiplier;
            return amount * multiplier;
        }

        public int IncreaseCustomScore(int increase)
        {
            score += increase;
            return increase;
        }
        public void ScoreFlag(int position)
        {
            int flagBase = 418;
            int flagTop = 140;
            int flagMultiplier = (flagBase-position) / (32);
            score += amount * flagMultiplier;

            if (position > flagTop)
            {
                IncrementLives();
            }
        }
        public void ResetScore()
        {
            score = 0;
        }

        public void ResetToLevelStart()
        {
            time = 12000;
            multiplier = 1;
        }

        public void ResetToGameStart()
        {
            time = 12000;
            multiplier = 1;
            coins = 0;
            score = 0;
            lives = 3;
        }
    }
}
