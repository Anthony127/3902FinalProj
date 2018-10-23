using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame
{
    public class KoopaPoppedSprite : ISprite
    {
        private Texture2D spriteSheet;
        private int currentFrame;
        private int totalFrames;

        public KoopaPoppedSprite(Texture2D texture)
        {
            spriteSheet = texture;
            currentFrame = 0;
            totalFrames = 30;
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 15)
            {
                sourceRectangle = new Rectangle(132, 0, 16, 27);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 27);
            }
            else
            {
                sourceRectangle = new Rectangle(92, 0, 16, 27);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 27);
            }
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color, MathHelper.Pi, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.None, 0);
            
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 27);
        }
    }
}
