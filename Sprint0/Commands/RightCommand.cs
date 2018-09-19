using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class RightCommand : ICommand
    {
        private Sprint0 sprint0;

        public RightCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.Mario.RunRight();
        }
    }
}
