using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.Blocks
{
    class ActivatedBlockState : IBlockState
    {
        private IBlock block;
        private string code = "ACTI";

        public ActivatedBlockState(IBlock block)
        {
            this.block = block;
        }
        public void Activate()
        {
        }

        public string GetStateCode()
        {
            return code;
        }
    }
}