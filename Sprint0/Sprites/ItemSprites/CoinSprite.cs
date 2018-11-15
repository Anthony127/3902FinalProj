using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CoinSprite : Sprite, ISprite
    {
        public CoinSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 8)
            {
                return new Rectangle(61, 177, 16, 16);
            }
            else if (CurrentFrame > 8 && CurrentFrame < 15)
            {
                return new Rectangle(77, 177, 16, 16);
            }
            else if (CurrentFrame > 15 && CurrentFrame < 23)
            {
                return new Rectangle(93, 177, 16, 16);
            }
            else
            {
                return new Rectangle(109, 177, 16, 16);
            }
        }
    }
}
