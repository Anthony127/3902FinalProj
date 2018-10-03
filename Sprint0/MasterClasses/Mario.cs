using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Sprint0.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Mario : IMario
    {
        private static Mario instance = new Mario();

        private IMovementState movementState;
        private IConditionState conditionState;
        private ISprite marioSprite;
        private Vector2 location;
        private Rectangle hitbox;
        private int damageTimer = 180;

        public static Mario Instance
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
            hitbox = new Rectangle((int) location.X, (int) location.Y, 13, 19);
            UpdateSprite();
        }

        public void Update()
        {
            marioSprite.Update();
            hitbox = new Rectangle((int)location.X, (int)location.Y, hitbox.Width, hitbox.Height);
            if (damageTimer != 180)
            {
                damageTimer++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (damageTimer % 3 == 0)
            {
                marioSprite.Draw(spriteBatch, location);
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
                Console.WriteLine("Changing from " + previousState + " to " + movementState.GetMovementCode());
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
                ResetDamageTimer();
                conditionState.TakeDamage();
                UpdateSprite();
            }
        }

        public void Idle()
        {
            if (movementState.GetMovementCode()[0] == 'L')
            {
                movementState = new MarioLeftIdleState(this);
            } else
            {
                movementState = new MarioRightIdleState(this);
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
    }
}
