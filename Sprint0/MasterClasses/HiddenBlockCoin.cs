using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.Sprites;
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

        public override void SpawnItem()
        {
            SoundFactory.Instance.PlaySoundEffect("SOUND_COIN");
            IItem coin = new BlockCoin
            {
                Location = new Vector2(this.Location.X, this.Location.Y - SpriteUtility.Instance.BLOCK_UNIT)
            };
            Level.PlayerLevel.Instance.ItemArray.Add(coin);
        }

        public override void Bump()
        {
            BlockState.Bump();
        }
    }
}