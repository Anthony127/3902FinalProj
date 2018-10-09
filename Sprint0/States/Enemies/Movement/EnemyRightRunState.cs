using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Enemies.Movement
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
        }

        public void Crouch()
        {
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
