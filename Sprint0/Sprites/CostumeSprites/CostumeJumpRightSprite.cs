using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeJumpRightSprite : CostumeSprite, ISprite
    {
        public CostumeJumpRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 9;
        }
    }
}