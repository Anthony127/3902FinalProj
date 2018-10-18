using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface IMovementState
    {
        string MovementCode { get; }
        void Jump();
        void Crouch();
        void RunRight();
        void RunLeft();

    }
}
