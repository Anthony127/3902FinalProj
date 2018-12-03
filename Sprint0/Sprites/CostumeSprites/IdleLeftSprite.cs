using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class IdleLeftSprite : CostumeSprite, ISprite
    {
        public IdleLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 23;
        }
    }
}
