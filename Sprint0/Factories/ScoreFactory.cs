using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class ScoreFactory
    {
        private static ScoreFactory instance = new ScoreFactory();

        public static ScoreFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ScoreFactory()
        {

        }
        
        public ScoreSprite CreateScore(int score, Vector2 location)
        {
            return new ScoreSprite(score, location);
        }
    }
}
