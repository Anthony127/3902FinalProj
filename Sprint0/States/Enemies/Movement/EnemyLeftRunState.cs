using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.States.BaseStates;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace SuperPixelBrosGame.States.Enemies.Movement
{
    class EnemyLeftRunState : MovementState, IMovementState
    {
        private IEnemy enemy;
        public override string MovementCode
        {
            get
            {
                return "LRUN";
            }
        }

        public EnemyLeftRunState(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.SetMovementState(this);
            enemy.UpdateSprite();
            IPhysics enemyPhysics = (IPhysics)enemy;
            enemyPhysics.Velocity = new Vector2(-1 * enemyPhysics.Velocity.X, enemyPhysics.Velocity.Y);
        }

        public override void RunRight()
        {
            enemy.SetMovementState(new EnemyRightRunState(enemy));
        }
    }
}
