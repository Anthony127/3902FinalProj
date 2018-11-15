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
    public class KoopaRightSprite : Sprite, ISprite
    {
        public KoopaRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 15)
            {
                return new Rectangle(268, 118, 17, 27);
            }
            else
            {
                return new Rectangle(239, 118, 17, 27);
            }
        }
    }
}

