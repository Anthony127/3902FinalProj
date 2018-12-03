using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class JumpLeftSprite : CostumeSprite, ISprite
    {
        public JumpLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 32;
        }
    }
}