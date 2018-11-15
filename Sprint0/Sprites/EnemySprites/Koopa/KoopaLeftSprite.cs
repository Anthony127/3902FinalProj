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
    public class KoopaLeftSprite : Sprite, ISprite
    {
        public KoopaLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 15)
            {
                return new Rectangle(132, 0, 16, 27);
            }
            else
            {
                return new Rectangle(92, 0, 16, 27);
            }
        }
    }
}
