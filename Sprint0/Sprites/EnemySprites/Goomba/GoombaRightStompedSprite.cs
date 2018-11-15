using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class GoombaRightStompedSprite : Sprite, ISprite
    {
        public GoombaRightStompedSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            Rectangle destinationRectangle = base.GetDestinationRectangle(location);
            return new Rectangle(destinationRectangle.X, destinationRectangle.Y + destinationRectangle.Height - 2, destinationRectangle.Width, destinationRectangle.Height / 8);
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(13, 285, 16, 16);
        }
    }
}