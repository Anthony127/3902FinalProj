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
        public Star()
        {
            id = "STAR";
            velocity = new Vector2(1, -5);
            UpdateSprite();
           hitbox = itemSprite.GetHitboxFromSprite(location);
        }

        public override void Bounce()
        {
            velocity = new Vector2(velocity.X, -8);
        }
    }
}