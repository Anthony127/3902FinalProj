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
        private readonly int BOUNCEVELOCITY = 8;
        public Star()
        {
            Velocity = new Vector2(1, -5);
        }

        public override void Bounce()
        {
            Velocity = new Vector2(Velocity.X, -BOUNCEVELOCITY);
        }
    }
}