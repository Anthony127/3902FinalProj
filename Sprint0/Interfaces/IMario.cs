using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    interface IMario
    {
        string GetMovementState();
        string GetConditionState();
        ISprite GetSprite();
        void SetMovementState(string movement);
        void SetConditionState(string condition);
        ISprite SetSprite();
       
    }
}
