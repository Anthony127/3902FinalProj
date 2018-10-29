using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class BrickBlock : Block, IBlock, ICollidable
    {
        public BrickBlock() : base()
        {
            id = "BB";
            UpdateSprite();
            hitbox = blockSprite.GetHitboxFromSprite(location);
        }

        public override void Bump()
        {
            blockState.Bump();
        }
    }
}
