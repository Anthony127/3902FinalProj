using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Blocks
{
    class ActivatedBlockState : BlockState, IBlockState
    {
        private IBlock block;
        public override string StateCode
        {
            get
            {
                return "ACTI";
            }
        }

        public ActivatedBlockState(IBlock block)
        {
            this.block = block;
            this.block.SpawnItem();
        }
    }
}