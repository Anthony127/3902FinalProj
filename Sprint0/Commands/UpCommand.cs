using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class UpCommand : ICommand
    {
        public void Execute()
        {
            Mario.Instance.Jump();
        }
    }
}
