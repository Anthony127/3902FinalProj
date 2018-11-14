﻿using Microsoft.Xna.Framework;
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

        public int Time { get => time / 60 + 1; set => time = value; }
        public int Score { get => score; set => score = value; }
        public int Coins { get => coins; set => coins = value; }
        public int Lives { get => lives; set => lives = value; }


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
        public int GetMultiplier()
        {
            return multiplier;
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
            }
        }

        public void IncreaseScore()
        {
            score += amount * multiplier;
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
            time = 24000;
            multiplier = 1;
        }

        public void ResetToGameStart()
        {
            time = 24000;
            multiplier = 1;
            coins = 0;
            score = 0;
        }
    }
}
