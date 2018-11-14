using Microsoft.Xna.Framework;
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
    public class ScoreSprite
    {
        private int score;
        private static SpriteFont font;
        private Vector2 spriteLocation;
        private int time;

        public ScoreSprite(int score, Vector2 spriteLocation)
        {
            this.score = score;
            this.spriteLocation = spriteLocation;
            this.time = 120;
        }

        public static void LoadContent(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("scorefont");
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(font, score.ToString(), spriteLocation, color);
        }

        public void Update()
        {
            time--;
            if (time % 10 == 0)
            {
                spriteLocation = new Vector2(spriteLocation.X, spriteLocation.Y - 1);
            }
            if (time == 0)
            {
                PlayerLevel.Instance.ScoreArray.Remove(this);
            }
        }
    }
}