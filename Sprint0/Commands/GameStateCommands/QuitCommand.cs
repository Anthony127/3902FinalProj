using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class QuitCommand : ICommand
    {
        private Sprint0 sprint0;

        public QuitCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            sprint0.ExitGame();
        }

    }
}
