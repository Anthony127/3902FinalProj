using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class MarioNegativeTransitionDecorator : IMario, ICollidable, IPhysics
    {
        IMario mario;
        IPhysics marioPhysics;
        ICollidable marioCollision;
        private int timer = 80;

        public IMovementState MovementState { get => mario.MovementState; set => mario.MovementState = value; }
        public IConditionState ConditionState { get => mario.ConditionState; set => mario.ConditionState = value; }
        public Vector2 Location { get => mario.Location; set => mario.Location = value; }
        public Rectangle Hitbox { get => marioCollision.Hitbox; set => marioCollision.Hitbox = value; }
        public Vector2 Velocity { get => marioPhysics.Velocity; set => marioPhysics.Velocity = value; }
        public Vector2 Friction { get => marioPhysics.Friction; set => marioPhysics.Friction = value; }

        public MarioNegativeTransitionDecorator(IMario mario)
        {
            this.mario = mario;
            marioPhysics = (IPhysics)mario;
            marioCollision = (ICollidable)mario;
        }
        public void CreateStarMario()
        {
            mario.CreateStarMario();
        }

        public void Crouch()
        {
            mario.Crouch();
        }

        public void Despawn()
        {
            marioCollision.Despawn();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            timer--;
            if (timer % 2 == 0)
            {
                mario.Draw(spriteBatch, location, color);
            }
            else
            {
                mario.Draw(spriteBatch, location, Color.Red);
            }
        }

        public void Idle()
        {
            mario.Idle();
        }

        public void Jump()
        {
            mario.Jump();
        }

        public void PowerUp()
        {
            mario.PowerUp();
        }

        public void Run()
        {
            mario.Run();
        }

        public void RunLeft()
        {
            mario.RunLeft();
        }

        public void RunRight()
        {
            mario.RunRight();
        }

        public void TakeDamage()
        {
            mario.TakeDamage();
        }

        public void ThrowFireBall()
        {
            mario.ThrowFireBall();
        }

        public void UnloadStarMario()
        {
            mario.UnloadStarMario();
        }

        public void Update()
        {
            mario.Update();
            if (timer < 0)
            {
                Mario.Instance = mario;
            }
        }

        public void UpdateSprite()
        {
            mario.UpdateSprite();
        }

        public void TransitionStatePositive()
        {
        }

        public void TransitionStateNegative()
        {
        }
    }
}