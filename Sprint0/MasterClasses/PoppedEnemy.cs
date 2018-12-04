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
        private int despawnTimer;
        public PoppedEnemy (IEnemy enemy)
        {
            this.enemy = enemy;
            enemyPhysics = (IPhysics)enemy;
            enemyCollision = (ICollidable)enemy;
            enemy.ConditionState = new EnemyPoppedState(enemy);
            enemy.MovementState = new EnemyPoppedMoveState(enemy);
            despawnTimer = 120;
        }

        public IMovementState MovementState { get => enemy.MovementState; set => enemy.MovementState = value; }
        public IConditionState ConditionState { get => enemy.ConditionState; set => enemy.ConditionState = value; }
        public Vector2 Location { get => enemy.Location; set => enemy.Location = value; }
        public Rectangle Hitbox { get => enemyCollision.Hitbox; set => enemyCollision.Hitbox = value; }
        public Vector2 Velocity { get => enemyPhysics.Velocity; set => enemyPhysics.Velocity = value; }
        public Vector2 Friction { get => enemyPhysics.Friction; set => enemyPhysics.Friction = value; }
        public int RowId { get => enemy.RowId; set => enemy.RowId = value; }

        public void Despawn()
        {
            enemyCollision.Despawn();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 Location, Color color)
        {
            enemy.Draw(spriteBatch, Location, color);
        }

        public void PopOff() { }

        public void RunLeft()
        {
            enemy.RunLeft();
        }

        public void RunRight()
        {
            enemy.RunRight();
        }

        public void TakeDamage()
        {
            enemy.TakeDamage();
        }

        public void Update()
        {
            enemy.Update();
            despawnTimer--;
            if (despawnTimer == 0)
            {
                PlayerLevel.Instance.DespawnList.Add(this);
            }
        }

        public void UpdateSprite()
        {
            enemy.UpdateSprite();
        }
    }
}
