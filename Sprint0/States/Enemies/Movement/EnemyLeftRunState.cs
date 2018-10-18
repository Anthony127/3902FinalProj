using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.States.BaseStates;

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
        }

        public override void RunRight()
        {
            enemy.SetMovementState(new EnemyRightRunState(enemy));
        }

        public override void RunLeft()
        {
            enemy.SetMovementState(new EnemyLeftRunState(enemy));
        }
    }
}
