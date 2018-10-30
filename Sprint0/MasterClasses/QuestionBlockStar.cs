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
    class QuestionBlockStar : Block, IBlock, ICollidable
    {

        public QuestionBlockStar()
        {
            Id = "QB";
            UpdateSprite();
           Hitbox = BlockSprite.GetHitboxFromSprite(Location);
        }

        public override void SpawnItem()
        {
            IItem star = new Star
            {
                Location = new Vector2(Location.X, Location.Y - 32)
            };
            PlayerLevel.Instance.ItemArray.Add(star);
        }

        public override void Bump()
        {
            BlockState.Bump();
        }
    }
}