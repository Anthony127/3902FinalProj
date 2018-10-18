using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.BaseStates
{
    abstract class MovementState : IMovementState
    {
        public virtual void Jump() { }
        public virtual void Crouch() { }
        public virtual void RunLeft() { }
        public virtual void RunRight() { }
        public virtual string MovementCode
        {
            get
            {
                return "";
            }
        }
    }
}
