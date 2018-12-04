using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeRightStompedSprite : CostumeSprite, ISprite
    {
        public CostumeRightStompedSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 2;
        }

        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            Rectangle destinationRectangle = base.GetDestinationRectangle(location);
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y + destinationRectangle.Height - 2, destinationRectangle.Width, destinationRectangle.Height / 8);
        }
    }
}