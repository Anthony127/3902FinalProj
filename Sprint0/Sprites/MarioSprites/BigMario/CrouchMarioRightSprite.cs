using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading;

namespace Sprint0.States.Mario
{
    class CrouchMarioRightSprite : ISprite
    {
        private Texture2D spriteSheet;

        public CrouchMarioRightSprite(Texture2D texture)
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


            sourceRectangle = new Rectangle(288, 122, 15, 14);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 14);

            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, color);
        }
    }
}
