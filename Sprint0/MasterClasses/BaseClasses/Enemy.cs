using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies.Condition;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.MasterClasses.BaseClasses
{
    class Enemy : IEnemy, IPhysics, ICollidable
    {
        protected Vector2 location;
        protected Rectangle hitbox;
        protected ISprite enemySprite;
        protected string id = "";
        protected Vector2 velocity;
        protected Vector2 friction;
        protected readonly Vector2 gravity = new Vector2(0, (float).3);
        protected IMovementState movementState;
        protected IConditionState conditionState;


        public IMovementState MovementState { get => movementState; set => movementState = value; }
        public IConditionState ConditionState { get => conditionState; set => conditionState = value; }
        public Vector2 Location { get => location; set => location = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Vector2 Friction { get => friction; set => friction = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }

        protected Enemy()
        {
            movementState = new EnemyLeftRunState(this);
            conditionState = new EnemyNormalState(this);
            location = new Vector2(0, 0);
            velocity = new Vector2(-1, 0);
            friction = new Vector2(0, 0);
        }

        public virtual void Despawn()
        {
            PlayerLevel.Instance.enemyArray.Remove(this);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            enemySprite.Draw(spriteBatch, location, color);
        }

        public virtual void PopOff()
        {
            PlayerLevel.Instance.enemyArray.Remove(this);
            PlayerLevel.Instance.enemyArray.Add(new PoppedEnemy(this));
        }

        public virtual void RunLeft()
        {
            movementState.RunLeft();
        }

        public virtual void RunRight()
        {
            movementState.RunRight();
        }

        public virtual void TakeDamage()
        {
            conditionState.TakeDamage();
        }

        public virtual void Update()
        {
            velocity.X += friction.X;
            velocity.Y += gravity.Y;
            location.X += velocity.X;
            location.Y += velocity.Y;
            enemySprite.Update();
            hitbox = enemySprite.GetHitboxFromSprite(location);
        }

        public void UpdateSprite()
        {
            enemySprite = EnemySpriteFactory.Instance.CreateSprite(movementState, conditionState, id);
        }
    }
}
