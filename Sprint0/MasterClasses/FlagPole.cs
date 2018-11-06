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
    public class FlagPole : Block, IBlock, ICollidable
    {
        private Flag flag;

        public Flag Flag { get => flag; set => flag = value; }
        public override Vector2 Location {get => base.Location; set { base.Location = value; flag.Location = new Vector2 (value.X - 52, value.Y + 24); } }

        public FlagPole()
        {
            Id = "FP";
            flag = new Flag();
            UpdateSprite();
            Hitbox = BlockSprite.GetHitboxFromSprite(Location);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 spriteLocation, Color color)
        {
            BlockSprite.Draw(spriteBatch, spriteLocation, color);
            Flag.Draw(spriteBatch, flag.Location, color);
        }
    }
}