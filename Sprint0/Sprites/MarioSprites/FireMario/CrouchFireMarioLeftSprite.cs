using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.States.Mario
{
        class CrouchFireMarioLeftSprite : ISprite
        {
        private Texture2D spriteSheet;

            public CrouchFireMarioLeftSprite(Texture2D texture)
            {
                spriteSheet = texture;
            }

            public void Update()
            {
                //no-op one frame
            }

            public void Draw(SpriteBatch spriteBatch, Vector2 location)
            {
                Rectangle sourceRectangle;
                Rectangle destinationRectangle;


                sourceRectangle = new Rectangle(88, 482, 15, 14);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 15, 14);

                spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
             }
        }
}
