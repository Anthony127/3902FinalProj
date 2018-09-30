using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.Blocks
{
    class NotActivatedBlockState : IBlockState
    {
        private IBlock block;
        private string code = "NACT";

        public NotActivatedBlockState(IBlock block)
        {
            this.block = block;
        }
        public void Activate()
        {
            block.SetBlockState(new ActivatedBlockState(block));
        }

        public string GetStateCode()
        {
            return code;
        }
    }
}
