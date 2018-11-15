using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class KoopaShellSprite : Sprite, ISprite
    {
        public KoopaShellSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y + 11, SourceRectangle.Width * SIZE_SCALAR, SourceRectangle.Height * SIZE_SCALAR);
        }

        public override Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y + 11, SourceRectangle.Width * SIZE_SCALAR, SourceRectangle.Height * SIZE_SCALAR);
        }

        protected override Rectangle GetSourceRectangle()
        {
                return new Rectangle(12, 86, 16, 16);
        }
    }
}
