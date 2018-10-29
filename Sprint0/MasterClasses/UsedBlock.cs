using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame
{
    class UsedBlock : Block, IBlock, ICollidable
    {

        public UsedBlock()
        {
            id = "SB";
            UpdateSprite();
           hitbox = blockSprite.GetHitboxFromSprite(location);
        }
    }
}
