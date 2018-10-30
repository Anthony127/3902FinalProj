using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class Mario : IMario, ICollidable, IPhysics
    {
        private static IMario instance = new Mario();

        private IMovementState movementState;
        private IConditionState conditionState;
        private ISprite marioSprite;
        private Vector2 location;
        private Vector2 velocity;
        private Vector2 friction;
        private readonly Vector2 gravity = new Vector2(0, (float) .3);
        private Rectangle hitbox;
        private int fireBallCooldown = 20;
        private int damageTimer;
        private float leftVelocityCap = -4;
        private float rightVelocityCap = 4;

        public static IMario Instance
        {
            get
            {
                return instance;
            }
        }

        public IMovementState MovementState { get => movementState; set => movementState = value; }
        public IConditionState ConditionState { get => conditionState; set => conditionState = value; }
        public Vector2 Location { get => location; set => location = value; }
        public Rectangle Hitbox { get => hitbox; set =>hitbox = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Vector2 Friction { get => friction; set => friction = value; }

        private Mario()
        {
            conditionState = new SmallMarioState(this);
            movementState = new MarioRightIdleState(this);
            friction = new Vector2(0, 0);
            location = new Vector2(0, 0);
            hitbox = marioSprite.GetHitboxFromSprite(location);
            damageTimer = 180;
        }

        public void Update()
        {
            velocity.X += friction.X;
            if ((velocity.X < .5 && velocity.X > -.5) && friction.X != 0)
            {
                Idle();
            }
            velocity.Y += gravity.Y;
            if (velocity.X > 0 && velocity.X > rightVelocityCap)
            {
                velocity.X = rightVelocityCap;
            }
            if (velocity.X < 0 && velocity.X < leftVelocityCap)
            {
                velocity.X = leftVelocityCap;
            }

            location.X += velocity.X;
            location.Y += velocity.Y;
            marioSprite.Update();
            hitbox = marioSprite.GetHitboxFromSprite(location);
            if (damageTimer != 180)
            {
                damageTimer++;
            }
            if (fireBallCooldown != 20)
            {
                fireBallCooldown++;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 spriteLocation, Color color)
        {
            if (damageTimer % 3 == 0)
            {
                marioSprite.Draw(spriteBatch, spriteLocation, color);
            }
        }

        public void CreateStarMario()
        {
            instance = new StarMario(this);
        }

        public void Crouch()
        {
            
            string previousState = movementState.MovementCode;
            movementState.Crouch();
            if (!previousState.Equals(movementState.MovementCode))
            {
                UpdateSprite();
            }
        }

        public void Jump()
        {
            string previousState = movementState.MovementCode;
            movementState.Jump();
            if (!previousState.Equals(movementState.MovementCode))
            {
                UpdateSprite();
            }
        }

        public void RunLeft()
        {
            string previousState = movementState.MovementCode;
            movementState.RunLeft();
            if (!previousState.Equals(movementState.MovementCode))
            {
                UpdateSprite();
            }
        }

        public void RunRight()
        {
            string previousState = movementState.MovementCode;
            movementState.RunRight();
            if (!previousState.Equals(movementState.MovementCode))
            {
                UpdateSprite();
            }
        }

        public void PowerUp()
        {
            conditionState.PowerUp();
            UpdateSprite();
        }

        public void TakeDamage()
        {
            if (damageTimer == 180)
            {
                conditionState.TakeDamage();
                if (!(conditionState is DeadMarioState))
                {
                    ResetDamageTimer();
                }
                UpdateSprite();
            }
        }

        public void Idle()
        {
            if (!(conditionState is DeadMarioState))
            {
                if (movementState.MovementCode[0] == 'L')
                {
                    movementState = new MarioLeftIdleState(this);
                }
                else
                {
                    movementState = new MarioRightIdleState(this);
                }
            }
            UpdateSprite();
        }

        private void ResetDamageTimer()
        {
            damageTimer = 0;
        }

        public void UpdateSprite()
        {
            marioSprite = PlayerSpriteFactory.Instance.CreateSprite(movementState, conditionState);
        }

        public void UnloadStarMario()
        {
            instance = this;
        }

        public void Despawn()
        {
            PlayerLevel.Instance.PlayerArray.Remove(this);
        }

        public void ThrowFireBall()
        {
            if (conditionState is FireMarioState)
            {
                if (fireBallCooldown == 20)
                {
                    IItem fireball = new FireBall();
                    fireball.Location = new Vector2(this.location.X + 10, this.location.Y + 4);
                    PlayerLevel.Instance.ItemArray.Add(fireball);
                    fireBallCooldown = 0;
                    if (movementState.MovementCode[0] == 'L')
                    {
                        IPhysics fireballPhysics = (IPhysics)fireball;
                        fireballPhysics.Velocity = new Vector2(-1 * fireballPhysics.Velocity.X, fireballPhysics.Velocity.Y);
                    }
                }
            }
        }
    }
}
