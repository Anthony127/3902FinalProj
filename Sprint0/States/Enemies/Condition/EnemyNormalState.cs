using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Enemies.Condition
{
    class EnemyNormalState : ConditionState, IConditionState
    {
        private IEnemy enemy;
        public override string ConditionCode
        {
            get
            {
                return "GOOD";
            }
        }

        public EnemyNormalState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public override void TakeDamage()
        {
            enemy.SetConditionState(new EnemyDefeatedState(enemy));
        }
    }
}
