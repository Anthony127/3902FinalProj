using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class GoombaLeftSprite : Sprite, ISprite
    {
        public GoombaLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 15)
            {
                return new Rectangle(12, 326, 16, 16);
            }
            else
            {
                return new Rectangle(52, 326, 16, 16);
            }
        }
    }
} 