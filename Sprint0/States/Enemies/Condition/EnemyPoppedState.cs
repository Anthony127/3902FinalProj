﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Enemies
{
    class EnemyPoppedState : ConditionState, IConditionState
    {
        private IEnemy enemy;
        public override string ConditionCode
        {
            get
            {
                return "POP";
            }
        }

        public EnemyPoppedState(IEnemy enemy)
        {
            this.enemy = enemy;
            enemy.SetConditionState(this);
            enemy.UpdateSprite();
        }
    }
}