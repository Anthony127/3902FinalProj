using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class WalkSmallMarioRightSprite : Sprite, ISprite
    {
        public WalkSmallMarioRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 8 || (CurrentFrame < 23 && CurrentFrame > 16))
            {
                return new Rectangle(206, 0, 16, 20);
            }
            else
            {
                return new Rectangle(326, 0, 16, 20);
            }

        }
    }
}
