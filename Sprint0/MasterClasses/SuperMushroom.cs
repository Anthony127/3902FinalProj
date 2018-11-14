using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class SuperMushroom : Item, IItem, ICollidable, IPhysics
    {
        private int spawnProtectionTimer = 14;
        private int BOUNCEVELOCITY = 4;

        public SuperMushroom()
        {
            Velocity = new Vector2((float)1.5, 0);
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
                Velocity = new Vector2(-1 * Velocity.X, -BOUNCEVELOCITY);
            }
        }
    }
}
