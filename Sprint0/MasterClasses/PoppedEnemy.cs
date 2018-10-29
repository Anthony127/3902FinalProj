using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Enemies.Movement;

namespace Sprint0.MasterClasses
{
    class PoppedEnemy : IEnemy, ICollidable, IPhysics
    {
        private IEnemy enemy;
        private IPhysics enemyPhysics;
        private ICollidable enemyCollision;
        private int despawnTimer = 120;
        public PoppedEnemy (IEnemy enemy)
        {
            this.enemy = enemy;
            this.enemyPhysics = (IPhysics)enemy;
            this.enemyCollision = (ICollidable)enemy;
            enemy.SetConditionState(new EnemyPoppedState(enemy));
            enemy.SetMovementState(new EnemyPoppedMoveState(enemy));
            despawnTimer--;
        }

        public Vector2 Velocity { get => enemyPhysics.Velocity; set => enemyPhysics.Velocity = value; }
        public Vector2 Friction { get => enemyPhysics.Friction; set => enemyPhysics.Friction = value; }
        public Vector2 Location { get => enemyPhysics.Location; set => enemyPhysics.Location = value; }

        public void Despawn()
        {
            enemyCollision.Despawn();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            enemy.Draw(spriteBatch, location, color);
        }

        public IConditionState GetConditionState()
        {
            return enemy.GetConditionState();
        }

        public Rectangle GetHitbox()
        {
            return enemyCollision.GetHitbox();
        }

        public Vector2 GetLocation()
        {
            return enemy.GetLocation();
        }

        public IMovementState GetMovementState()
        {
            return enemy.GetMovementState();
        }

        public void PopOff()
        {

        }

        public void RunLeft()
        {
            enemy.RunLeft();
        }

        public void RunRight()
        {
            enemy.RunRight();
        }

        public void SetConditionState(IConditionState condition)
        {
            enemy.SetConditionState(condition);
        }

        public void SetHitbox(Rectangle hitbox)
        {
            enemyCollision.SetHitbox(hitbox);
        }

        public void SetLocation(Vector2 location)
        {
            enemy.SetLocation(location);
        }

        public void SetMovementState(IMovementState movement)
        {
            enemy.SetMovementState(movement);
        }

        public void TakeDamage()
        {
            enemy.TakeDamage();
        }

        public void Update()
        {
            enemy.Update();
        }

        public void UpdateSprite()
        {
            enemy.UpdateSprite();
        }

        public Vector2 GetVelocity()
        {
            return ((IPhysics)enemy).Velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            ((IPhysics)enemy).Velocity = velocity;
        }
    }
}
