﻿using Microsoft.Xna.Framework;
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
        private readonly int FIREBALLSPEED = 6;

        public FireBall()
        {
            SoundFactory.Instance.PlaySoundEffect("SOUND_FIREBALL");
            Velocity = new Vector2(FIREBALLSPEED,0);
            fireBallTimeout = 90;
        }

        public override void Update()
        {
            fireBallTimeout--;
            if (fireBallTimeout == 0)
            {
                PlayerLevel.Instance.DespawnList.Add(this);
            }
            else
            {
                base.Update();
            }

        }

        public override void Bounce()
        {
            int BOUNCESPEED = -4;
            Velocity = new Vector2(Velocity.X, BOUNCESPEED);
        }
    }
}