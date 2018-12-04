using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeJumpLeftSprite : CostumeSprite, ISprite
    {
        public CostumeJumpLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 32;
        }
    }
}