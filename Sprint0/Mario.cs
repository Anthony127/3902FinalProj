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

        public void SetConditionState(IConditionState condition)
        {
            conditionState = condition;
        }

        public void SetMovementState(IMovementState movement)
        {
            movementState = movement;
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
