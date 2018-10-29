using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;


namespace SuperPixelBrosGame.MasterClasses
{
    class FireBall : Item, IItem, ICollidable, IPhysics
    {
        private int fireBallTimeout;

        public FireBall()
        {
            velocity = new Vector2(4,0);
            id = "FIBA";
            fireBallTimeout = 90;
            UpdateSprite();
            hitbox = itemSprite.GetHitboxFromSprite(location);
        }

        public override void Update()
        {
            base.Update();
            fireBallTimeout--;
            if (fireBallTimeout == 0)
            {
                PlayerLevel.Instance.despawnList.Add(this);
            }
        }

        public override void Bounce()
        {
            velocity = new Vector2(velocity.X, -4);
        }
    }
}