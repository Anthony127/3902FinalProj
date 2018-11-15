using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class JumpSmallMarioRightSprite : Sprite, ISprite
    {
        public JumpSmallMarioRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(208, 40, 16, 20);
        }
    }
}


