using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class IdleSmallMarioRightSprite : Sprite, ISprite
    {
        public IdleSmallMarioRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(206, 0, 16, 20);
        }
    }
}

