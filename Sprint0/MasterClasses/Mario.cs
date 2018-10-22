using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
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
        private Vector2 gravity = new Vector2(0, (float) .3);
        private Rectangle hitbox;
        private int damageTimer;

        public static IMario Instance
        {
            get
            {
                return instance;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public Vector2 Friction
        {
            get
            {
                return friction;
            }
            set
            {
                friction = value;
            }
        }

        public Mario()
        {
            conditionState = new SmallMarioState(this);
            movementState = new MarioRightIdleState(this);
            friction = new Vector2(0, 0);
            location = new Vector2(0, 0);
            hitbox = marioSprite.GetHitboxFromSprite(GetLocation());
            damageTimer = 180;
        }

        public void Update()
        {
            velocity.X += friction.X;
            if ((velocity.X < .4 && velocity.X > -.4) && friction.X != 0)
            {
                Idle();
            }
            velocity.Y += gravity.Y;

            location.X += velocity.X;
            location.Y += velocity.Y;
            marioSprite.Update();
            hitbox = marioSprite.GetHitboxFromSprite(GetLocation());
            Console.WriteLine("X Velocity: " + velocity.X + " Y Velocity: " + velocity.Y + " X Friction: " + friction.X);
            if (damageTimer != 180)
            {
                damageTimer++;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (damageTimer % 3 == 0)
            {
                marioSprite.Draw(spriteBatch, location, color);
            }
        }

        public void CreateStarMario()
        {
            instance = new StarMario(this);
        }

        public IConditionState GetConditionState()
        {
            return conditionState;
        }

        public IMovementState GetMovementState()
        {
            return movementState;
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }


        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        public void SetConditionState(IConditionState condition)
        {
            conditionState = condition;
        }

        public void SetMovementState(IMovementState movement)
        {
            movementState = movement;
        }
        public void SetHitbox(Rectangle hitbox)
        {
            this.hitbox = hitbox;
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
    }
}
