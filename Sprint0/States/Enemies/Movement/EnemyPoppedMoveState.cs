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
    class EnemyPoppedMoveState : MovementState, IMovementState
    {
        private IEnemy enemy;
        public override string MovementCode
        {
            get
            {
                return "POP";
            }
        }

        public EnemyPoppedMoveState(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.MovementState = this;
            enemy.UpdateSprite();
            IPhysics enemyPhysics = (IPhysics)enemy;
            enemyPhysics.Velocity = new Vector2(2, -3);
        }
    }
}
