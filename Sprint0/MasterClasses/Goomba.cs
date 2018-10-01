using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.States.Enemies.Condition;
using Sprint0.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class Goomba : IEnemy
    {
        private IMovementState movementState;
        private IConditionState conditionState;
        private ISprite goombaSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "GM";

        public Goomba()
        {
            movementState = new EnemyLeftRunState(this);
            conditionState = new EnemyNormalState(this);
            location = new Vector2(0, 0);
            hitbox = new Rectangle((int)location.X, (int)location.Y, 16, 15);
            UpdateSprite();
        }

        public void Update()
        {
            goombaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            goombaSprite.Draw(spriteBatch, location);
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

        public void RunLeft()
        {
            movementState.RunLeft();
        }

        public void RunRight()
        {
            movementState.RunRight();
        }

        public void TakeDamage()
        {
            conditionState.TakeDamage();
        }

        private void UpdateSprite()
        {
            goombaSprite = EnemySpriteFactory.Instance.CreateSprite(movementState, conditionState, ID);
        }
    }
}
