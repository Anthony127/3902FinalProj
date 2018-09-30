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

        public static Mario Instance
        {
            get
            {
                return instance;
            }
        }

        public Mario()
        {
            movementState = new MarioLeftIdleState(this);
            conditionState = new SmallMarioState(this);
            location = new Vector2(0, 0);
            hitbox = new Rectangle((int) location.X, (int) location.Y, 13, 19);
            UpdateSprite();
        }

        public void Update()
        {
            marioSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            marioSprite.Draw(spriteBatch, location);
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
            movementState.Crouch();
            UpdateSprite();
        }

        public void Jump()
        {
            movementState.Jump();
            UpdateSprite();
        }

        public void RunLeft()
        {
            movementState.RunLeft();
            UpdateSprite();
        }

        public void RunRight()
        {
            movementState.RunRight();
            UpdateSprite();
        }

        public void PowerUp()
        {
            conditionState.PowerUp();
            UpdateSprite();
        }

        public void TakeDamage()
        {
            conditionState.TakeDamage();
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            marioSprite = PlayerSpriteFactory.Instance.CreateSprite(movementState, conditionState);
        }
    }
}
