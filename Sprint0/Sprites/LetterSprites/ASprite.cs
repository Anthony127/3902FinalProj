using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States;

namespace SuperPixelBrosGame
{
    public class ASprite : ISprite
    {

        private Texture2D letterTexture;
        private const int SIZE_SCALAR = 2;
        private const int LETTER_WIDTH = 6;
        private const int LETTER_HEIGHT = 7;

        public ASprite(Texture2D texture)
        {
            letterTexture = texture;
        }

        public void Update()
        {
            //no-op
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(0, 0, LETTER_WIDTH, LETTER_HEIGHT);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LETTER_WIDTH * SIZE_SCALAR, LETTER_HEIGHT * SIZE_SCALAR);

            spriteBatch.Draw(letterTexture, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 0, 0);
        }
    }
}