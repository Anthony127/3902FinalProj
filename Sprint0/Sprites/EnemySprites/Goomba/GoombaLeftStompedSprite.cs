using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class GoombaLeftStompedSprite : Sprite, ISprite
    {
        public GoombaLeftStompedSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            Rectangle destinationRectangle = base.GetDestinationRectangle(location);
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y + destinationRectangle.Height - 2, destinationRectangle.Width, destinationRectangle.Height / 8);
        }

        protected override Rectangle GetSourceRectangle()
        {
                return new Rectangle(12, 326, 16, 16);
        }
    }
}