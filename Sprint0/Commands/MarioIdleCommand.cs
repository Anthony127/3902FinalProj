using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class MarioIdleCommand : ICommand
    {
        public void Execute()
        {
            Mario.Instance.Idle();
            Console.WriteLine("IDLING");
        }
    }
}
