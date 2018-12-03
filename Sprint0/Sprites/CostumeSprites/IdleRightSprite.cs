using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class IdleRightSprite : CostumeSprite, ISprite
    {
        public IdleRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 0;
        }
    }
}

