using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Enemies.Condition
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
