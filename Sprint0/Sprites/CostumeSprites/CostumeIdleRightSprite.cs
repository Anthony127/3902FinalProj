using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeIdleRightSprite : CostumeSprite, ISprite
    {
        public CostumeIdleRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 0;
        }
    }
}

