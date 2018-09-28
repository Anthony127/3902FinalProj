using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IMovementState
    {
        void Jump();
        void Crouch();
        void RunRight();
        void RunLeft();
        string GetMovementCode();

    }
}
