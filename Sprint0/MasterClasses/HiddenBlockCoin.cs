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
    class HiddenBlockCoin : Block, IBlock, ICollidable
    {
        public HiddenBlockCoin()
        {
            id = "HB";
            UpdateSprite();
            hitbox = blockSprite.GetHitboxFromSprite(location);
        }

        public override void SpawnItem()
        {
            IItem coin = new Coin
            {
                Location = new Vector2(this.location.X, this.location.Y - 32)
            };
            Level.PlayerLevel.Instance.itemArray.Add(coin);
        }

        public override void Bump()
        {
            blockState.Bump();
        }
    }
}