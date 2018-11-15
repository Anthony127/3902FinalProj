using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class WalkSmallMarioLeftSprite : Sprite, ISprite
    {
        public WalkSmallMarioLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 8 || (CurrentFrame < 23 && CurrentFrame > 16))
            {
                return new Rectangle(166, 0, 16, 20);
            }
            else
            {
                return new Rectangle(48, 0, 16, 20);
            }

        }
    }
}



