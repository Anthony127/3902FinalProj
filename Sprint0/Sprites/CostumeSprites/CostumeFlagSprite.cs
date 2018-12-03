﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeFlagSprite : CostumeSprite, ISprite
    {
        public CostumeFlagSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
            ColId = 19;
        }    
    }
}