using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;


namespace SuperPixelBrosGame.MasterClasses
{
    class FireBallExploded : Item, IItem, ICollidable, IPhysics
    {
        private int fireBallTimeout;

        public FireBallExploded()
        {
            Velocity = new Vector2(0, 0);
            fireBallTimeout = 10;
        }

        public override void Update()
        {
            fireBallTimeout--;
            if (fireBallTimeout == 0)
            {
                PlayerLevel.Instance.DespawnList.Add(this);
            }

        }
    }
}