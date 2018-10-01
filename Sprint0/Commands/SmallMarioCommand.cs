﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class SmallMarioCommand : ICommand
    {
        private Sprint0 sprint0;

        public SmallMarioCommand(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
        }

        public void Execute()
        {
            Mario.Instance.TakeDamage();
        }
    }
}
