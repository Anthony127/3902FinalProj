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
    class HiddenBlockStar : Block, IBlock, ICollidable
    {
        public HiddenBlockStar()
        {
            id = "HB";
            UpdateSprite();
            hitbox = blockSprite.GetHitboxFromSprite(location);
        }

        public override void SpawnItem()
        {
            IItem star = new Star
            {
                Location = new Vector2(this.location.X, this.location.Y - 32)
            };
            Level.PlayerLevel.Instance.itemArray.Add(star);
        }

        public override void Bump()
        {
            blockState.Bump();
        }
    }
}