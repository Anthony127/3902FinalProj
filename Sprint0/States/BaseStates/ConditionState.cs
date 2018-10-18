using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.BaseStates
{
    abstract class ConditionState : IConditionState
    {
        public virtual void PowerUp() { }
        public virtual void TakeDamage() { }
        public virtual string ConditionCode
        {
            get
            {
                return "";
            }
        }
    }
}
