using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Sprites;
using System.Threading;

namespace SuperPixelBrosGame.States.Mario
{
    class WalkFireMarioRightSprite : Sprite, ISprite
    {
        public WalkFireMarioRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 5 || (CurrentFrame < 20 && CurrentFrame > 16))
            {
                return new Rectangle(208, 432, 16, 32);
            }
            else if (CurrentFrame < 10 || (CurrentFrame < 25 && CurrentFrame > 21))
            {
                return new Rectangle(328, 432, 16, 32);
            }
            else
            {
                return new Rectangle(368, 432, 16, 32);
            }
        }
    }
}

