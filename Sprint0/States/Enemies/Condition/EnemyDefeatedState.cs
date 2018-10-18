﻿using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Enemies
{
    class EnemyDefeatedState : ConditionState, IConditionState
    {
        private IEnemy enemy;
        public override string ConditionCode
        {
            get
            {
                return "DEAD";
            }
        }

        public EnemyDefeatedState(IEnemy enemy)
        {
            this.enemy = enemy;
        }
    }
}
