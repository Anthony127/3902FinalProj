using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class OneUpMushroom : Item, IItem, ICollidable, IPhysics
    {
        private int spawnProtectionTimer = 10;

        public OneUpMushroom()
        {
            Id = "ONEU";
            Velocity = new Vector2((float)1.5, 0);
            UpdateSprite();
           Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }

        public override void Update()
        {
            base.Update();
            spawnProtectionTimer--;
        }

        public override void Bounce()
        {
            if (spawnProtectionTimer <= 0)
            {
                Velocity = new Vector2(-1 * Velocity.X, -4);
            }
        }
    }
}