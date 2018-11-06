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
    public class Flag : Block, IBlock, ICollidable
    {

        public Flag()
        {
            Id = "FG";
            UpdateSprite();
            Hitbox = BlockSprite.GetHitboxFromSprite(Location);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 spriteLocation, Color color)
        {
            BlockSprite.Draw(spriteBatch, spriteLocation, color);
        }
    }
}