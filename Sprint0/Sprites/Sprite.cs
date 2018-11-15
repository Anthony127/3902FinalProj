using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Sprites
{
    public abstract class Sprite : ISprite
    {
        private Rectangle sourceRectangle;
        private readonly int SIZE_SCALAR = 2;
        private int currentFrame;
        private readonly int totalFrames = 30;
        private Texture2D spriteSheet;

        protected int CurrentFrame {get => currentFrame;}
        protected Texture2D SpriteSheet { get => spriteSheet; }

        protected Rectangle SourceRectangle { get => sourceRectangle; set => sourceRectangle = value; }


        public Sprite(Texture2D spriteSheet)
        {
            currentFrame = 0;
            this.spriteSheet = spriteSheet;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sourceRectangle = GetSourceRectangle();
            Rectangle destinationRectangle = GetDestinationRectangle(location);
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        protected abstract Rectangle GetSourceRectangle();

        protected virtual Rectangle GetDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, sourceRectangle.Width * SIZE_SCALAR, sourceRectangle.Height * SIZE_SCALAR);
        }
        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, sourceRectangle.Width * SIZE_SCALAR, sourceRectangle.Height * SIZE_SCALAR);
        }

        public virtual void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }
    }
}
