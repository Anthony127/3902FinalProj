using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class BigMarioCommand : ICommand
    {

        public void Execute()
        {
            Mario.Instance.PowerUp();
        }
    }
}
