using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class GoombaRightSprite : Sprite, ISprite
    {
        public GoombaRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 15)
            {
                return new Rectangle(13, 285, 16, 16);
            }
            else
            {
                return new Rectangle(53, 284, 16, 16);
            }
        }
    }
}