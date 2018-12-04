using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;
using SuperPixelBrosGame.MasterClasses;

namespace SuperPixelBrosGame
{
    public class CostumeCrouchRightSprite : CostumeSprite, ISprite
    {
        public CostumeCrouchRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 1;
        }

        public override Rectangle GetHitboxFromSprite(Vector2 location)
        {

                return new Rectangle((int)location.X, (int)location.Y + (SourceRectangle.Height * SIZE_SCALAR) / 2, SourceRectangle.Width * SIZE_SCALAR, (SourceRectangle.Height / 2) * SIZE_SCALAR);

        }
    }
}