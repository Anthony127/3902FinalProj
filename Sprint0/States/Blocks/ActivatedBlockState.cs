using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Blocks
{
    class ActivatedBlockState : IBlockState
    {
        private IBlock block;
        private string code = "ACTI";

        public ActivatedBlockState(IBlock block)
        {
            this.block = block;
            this.block.SpawnItem();
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