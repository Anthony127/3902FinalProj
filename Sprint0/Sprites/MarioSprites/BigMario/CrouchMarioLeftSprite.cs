﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CrouchMarioLeftSprite : Sprite, ISprite
    {
        public CrouchMarioLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(88, 106, 16, 32);
        }

        public override Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y + 16 * SIZE_SCALAR, SourceRectangle.Width * SIZE_SCALAR, (SourceRectangle.Height / 2) * SIZE_SCALAR);
        }
    }
}
