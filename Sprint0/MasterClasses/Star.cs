using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class Star : Item, IItem, ICollidable, IPhysics
    {
        private int BOUNCEVELOCITY = 8;
        public Star()
        {
            Id = "STAR";
            Velocity = new Vector2(1, -5);
            UpdateSprite();
           Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }

        public override void Bounce()
        {
            Velocity = new Vector2(Velocity.X, -BOUNCEVELOCITY);
        }
    }
}