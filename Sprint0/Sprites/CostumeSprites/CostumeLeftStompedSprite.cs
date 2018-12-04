using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeLeftStompedSprite : CostumeSprite, ISprite
    {
        public CostumeLeftStompedSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 25;
        }

        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            Rectangle destinationRectangle = base.GetDestinationRectangle(location);
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y + destinationRectangle.Height - 2, destinationRectangle.Width, destinationRectangle.Height / 8);
        }
    }
}