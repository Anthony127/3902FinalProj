using Microsoft.Xna.Framework;
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
    class BrickBlockWithCoin : Block, IBlock, ICollidable
    {

        public BrickBlockWithCoin()
        {
            id = "BI";
            UpdateSprite();
            hitbox = blockSprite.GetHitboxFromSprite(location);
        }

        public override void SpawnItem()
        {
            IItem coin = new Coin
            {
                Location = new Vector2(location.X, location.Y - 32)
            };
            Level.PlayerLevel.Instance.itemArray.Add(coin);
        }

        public override void Bump()
        {
            blockState.Bump();
        }
    }
}
