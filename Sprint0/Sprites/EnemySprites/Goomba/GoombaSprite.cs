using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class GoombaSprite : ISprite
    {

        private Texture2D spriteSheet;
        public GoombaSprite(Texture2D texture)
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

            sourceRectangle = new Rectangle(12, 326, 16, 15);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 15);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
            
        }
    }
} 