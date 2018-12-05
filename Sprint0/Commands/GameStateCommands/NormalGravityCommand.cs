using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class NormalGravityCommand : ICommand
    {

        public NormalGravityCommand()
        {
        }

        public void Execute()
        {
            PhysicsUtility.Instance.EnableNormalGravity();
        }

    }
}
