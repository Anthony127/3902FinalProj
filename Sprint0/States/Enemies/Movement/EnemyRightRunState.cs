using Sprint0.Interfaces;
using Sprint0.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.Enemies.Movement
{
    class EnemyRightRunState : IMovementState
    {
        private IEnemy enemy;
        private string code = "RRUN";

        public EnemyRightRunState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void Jump()
        {
            //no-op
        }

        public void Crouch()
        {
            //no-op
        }

        public void RunRight()
        {
            
        }

        public void RunLeft()
        {
            enemy.SetMovementState(new EnemyLeftRunState(enemy));
        }

        public string GetMovementCode()
        {
            return code;
        }
    }
}
