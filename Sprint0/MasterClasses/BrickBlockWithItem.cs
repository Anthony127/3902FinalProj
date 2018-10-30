using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class BrickBlockWithItem : Block, IBlock, ICollidable
    {

        public BrickBlockWithItem()
        {
            Id = "BI";
            UpdateSprite();
            Hitbox = BlockSprite.GetHitboxFromSprite(Location);
        }

        public override void SpawnItem()
        {
            if (Mario.Instance.ConditionState is SmallMarioState)
            {
                IItem powerup = new SuperMushroom
                {
                    Location = new Vector2(Location.X, Location.Y - 32)
                };
                PlayerLevel.Instance.ItemArray.Add(powerup);
            }
            else
            {
                IItem powerup = new FireFlower
                {
                    Location = new Vector2(Location.X, Location.Y - 32)
                };
                PlayerLevel.Instance.ItemArray.Add(powerup);
            }
        }

        public override void Bump()
        {
            BlockState.Bump();
        }
    }
}
