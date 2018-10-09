using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    class Mario : IMario, ICollidable
    {
        private static IMario instance = new Mario();

        private IMovementState movementState;
        private IConditionState conditionState;
        private ISprite marioSprite;
        private Vector2 location;
        private Rectangle hitbox;
        private int damageTimer;

        public static IMario Instance
        {
            get
            {
                return instance;
            }
        }

        public Mario()
        {
            movementState = new MarioRightIdleState(this);
            conditionState = new SmallMarioState(this);
            location = new Vector2(0, 0);
            UpdateSprite();
            hitbox = marioSprite.GetHitboxFromSprite(GetLocation());
            damageTimer = 180;
        }

        public void Update()
        {

            marioSprite.Update();
            hitbox = marioSprite.GetHitboxFromSprite(GetLocation());
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

        public void CreateStarMario()
        {
            instance = new StarMario(this);
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
            
            string previousState = movementState.GetMovementCode();
            movementState.Crouch();
            if (!previousState.Equals(movementState.GetMovementCode()))
            {
                UpdateSprite();
            }
        }

        public void Jump()
        {
            string previousState = movementState.GetMovementCode();
            movementState.Jump();
            if (!previousState.Equals(movementState.GetMovementCode()))
            {
                UpdateSprite();
            }
        }

        public void RunLeft()
        {
            string previousState = movementState.GetMovementCode();
            movementState.RunLeft();
            if (!previousState.Equals(movementState.GetMovementCode()))
            {
                UpdateSprite();
            }
        }

        public void RunRight()
        {
            string previousState = movementState.GetMovementCode();
            movementState.RunRight();
            if (!previousState.Equals(movementState.GetMovementCode()))
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
                if (movementState.GetMovementCode()[0] == 'L')
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

        private void UpdateSprite()
        {
            marioSprite = PlayerSpriteFactory.Instance.CreateSprite(movementState, conditionState);
        }

        public void UnloadStarMario()
        {
            instance = this;
        }
    }
}
