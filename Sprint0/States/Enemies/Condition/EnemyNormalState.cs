using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.Enemies.Condition
{
    class EnemyNormalState : IConditionState
    {
        private IEnemy enemy;
        private string code = "GOOD";

        public EnemyNormalState(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void PowerUp()
        {
            //no-op
        }

        public void TakeDamage()
        {
            enemy.SetConditionState(new EnemyDefeatedState(enemy));
        }

        public string GetConditionCode()
        {
            return code;
        }
    }
}
