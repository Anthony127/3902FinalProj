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
            enemy.ConditionState = this;
            enemy.UpdateSprite();
        }

        public override void TakeDamage()
        {
            enemy.ConditionState = new EnemyDefeatedState(enemy);
        }
    }
}
