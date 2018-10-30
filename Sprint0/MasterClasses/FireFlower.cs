using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class FireFlower : Item, IItem, ICollidable, IPhysics
    {

        public FireFlower()
        {
            Id = "FIRE";
            UpdateSprite();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);

        }

        public override void Update()
        {
            ItemSprite.Update();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }
    }
}