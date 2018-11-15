using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Sprites;
using System.Threading;

namespace SuperPixelBrosGame.States.Mario
{
    class WalkMarioLeftSprite : Sprite, ISprite
    {
        public WalkMarioLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 5 || (CurrentFrame < 20 && CurrentFrame > 16))
            {
                return new Rectangle(168, 72, 16, 32);
            }
            else if (CurrentFrame < 10 || (CurrentFrame < 25 && CurrentFrame > 21))
            {
                return new Rectangle(48, 72, 16, 32);
            }
            else
            {
                return new Rectangle(8, 72, 16, 32);
            }
        }
    }
}
