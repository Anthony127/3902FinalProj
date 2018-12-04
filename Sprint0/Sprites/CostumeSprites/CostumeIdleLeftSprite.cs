using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeIdleLeftSprite : CostumeSprite, ISprite
    {
        public CostumeIdleLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 23;
        }
    }
}
