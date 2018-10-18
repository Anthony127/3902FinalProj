using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.States.BaseStates;

namespace SuperPixelBrosGame.States.Enemies.Movement
{
    class EnemyRightRunState : MovementState, IMovementState
    {
        private IEnemy enemy;
        public override string MovementCode
        {
            get
            {
                return "RRUN";
            }
        }

        public EnemyRightRunState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public override void RunLeft()
        {
            enemy.SetMovementState(new EnemyLeftRunState(enemy));
        }
    }
}
