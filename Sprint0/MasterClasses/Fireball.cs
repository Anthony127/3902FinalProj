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
            SoundFactory.Instance.PlaySoundEffect("SOUND_FIREBALL");
            Velocity = new Vector2(6,0);
            Id = "FIBA";
            fireBallTimeout = 90;
            UpdateSprite();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }

        public override void Update()
        {
            fireBallTimeout--;
            if (fireBallTimeout == 0)
            {
                PlayerLevel.Instance.DespawnList.Add(this);
            }
            if (Id.Equals("FIEX"))
            {

                UpdateSprite();
                ItemSprite.Update();
                if (fireBallTimeout > 10)
                {
                    fireBallTimeout = 10;
                }
            }
            else
            {
                base.Update();
            }

        }

        public override void Bounce()
        {
            Velocity = new Vector2(Velocity.X, -4);
        }
    }
}