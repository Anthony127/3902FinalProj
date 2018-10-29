﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class GroundBlock : Block, IBlock, ICollidable
    {
        public GroundBlock()
        {
            id = "GB";
            UpdateSprite();
            hitbox = blockSprite.GetHitboxFromSprite(location);
        }
    }
}