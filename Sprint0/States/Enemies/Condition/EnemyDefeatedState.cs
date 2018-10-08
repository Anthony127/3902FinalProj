using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.Enemies
{
    class EnemyDefeatedState : IConditionState
    {
        private IEnemy enemy;
        private string code = "DEAD";

        public EnemyDefeatedState(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void PowerUp()
        {
        }

        public void TakeDamage()
        {
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}
