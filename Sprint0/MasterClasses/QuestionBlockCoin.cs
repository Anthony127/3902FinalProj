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
    class QuestionBlockCoin : Block, IBlock, ICollidable
    {

        public QuestionBlockCoin()
        {
            Id = "QB";
            UpdateSprite();
           Hitbox = BlockSprite.GetHitboxFromSprite(Location);
        }

        public override void SpawnItem()
        {
            IItem coin = new BlockCoin
            {
                Location = new Vector2(Location.X, Location.Y - 32)
            };
            Level.PlayerLevel.Instance.ItemArray.Add(coin);
        }

        public override void Bump()
        {
            BlockState.Bump();
        }
    }
}