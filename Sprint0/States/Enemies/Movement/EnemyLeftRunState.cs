using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.Enemies.Movement
{
    class EnemyLeftRunState : IMovementState
    {
        private IEnemy enemy;
        private string code = "LRUN";

        public EnemyLeftRunState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void Jump()
        {
        }

        public void Crouch()
        {
        }

        public void RunRight()
        {
            enemy.SetMovementState(new EnemyRightRunState(enemy));
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
