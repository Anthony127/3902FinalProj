using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class JumpFireMarioRightSprite : Sprite, ISprite
    {
        public JumpFireMarioRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(208, 474, 16, 32);
        }
    }
}