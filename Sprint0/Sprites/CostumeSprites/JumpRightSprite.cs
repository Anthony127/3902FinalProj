using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class JumpRightSprite : CostumeSprite, ISprite
    {
        public JumpRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 9;
        }
    }
}