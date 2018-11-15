using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using System.Collections.Generic;
using System;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public static class ScoreFactory
    {
        
        public static ScoreSprite CreateScore(int score, Vector2 location)
        {
            return new ScoreSprite(score, location);
        }
    }
}
