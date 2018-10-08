using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class DeadMarioSprite : ISprite
    {
        private Texture2D spriteSheet;

        public DeadMarioSprite(Texture2D texture)
        {
            spriteSheet = texture;
        }

        public void Update()
        {
            //no-op one frame
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            sourceRectangle = new Rectangle(8, 38, 16, 24);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 24);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }

        public Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 24);
        }
    }
}