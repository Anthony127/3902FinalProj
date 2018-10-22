using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies.Condition;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class Koopa : IEnemy, ICollidable, IPhysics
    {
        private IMovementState movementState;
        private IConditionState conditionState;
        private ISprite koopaSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private Vector2 velocity;
        private Vector2 friction;
        private Vector2 gravity = new Vector2(0, (float).2);
        private readonly string ID = "KP";
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

        public Vector2 Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public Koopa()
        {
            movementState = new EnemyLeftRunState(this);
            conditionState = new EnemyNormalState(this);
            location = new Vector2(0, 0);
            velocity = new Vector2(-1, 0);
            friction = new Vector2(0, 0);
            UpdateSprite();
            hitbox = koopaSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Update()
        {
            velocity.Y += gravity.Y;
            location.X += velocity.X;
            location.Y += velocity.Y;
            koopaSprite.Update();
            hitbox = koopaSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            koopaSprite.Draw(spriteBatch, location, color);
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
            hitbox = new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }

        public void UpdateSprite()
        {
            koopaSprite = EnemySpriteFactory.Instance.CreateSprite(movementState, conditionState, ID);
        }
    }
}
