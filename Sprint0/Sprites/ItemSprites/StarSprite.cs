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
    public class StarSprite : Sprite, ISprite
    {
        public StarSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 15)
            {
                return new Rectangle(25, 23, 16, 16);
            }
            else
            {
                return new Rectangle(43, 23, 16, 16);
            }
        }
    }
}
