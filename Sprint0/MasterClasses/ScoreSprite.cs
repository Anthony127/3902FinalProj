﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class ScoreSprite : ISprite
    {
        private int score;
        private static SpriteFont font;
        private Vector2 spriteLocation;
        private int time;

        public ScoreSprite(int score, Vector2 spriteLocation)
        {
            this.score = score;
            this.spriteLocation = spriteLocation;
            time = 120;
        }

        public static void LoadContent(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("scorefont");
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            spriteBatch.DrawString(font, score.ToString(), spriteLocation, color);
        }

        public void Update()
        {
            time--;
            if (time % 2 == 0)
            {
                spriteLocation = new Vector2(spriteLocation.X, spriteLocation.Y - 1);
            }
            if (time == 0)
            {
                PlayerLevel.Instance.ScoresToDelete.Add(this);
            }
        }

        public Rectangle GetHitboxFromSprite(Vector2 vector)
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}