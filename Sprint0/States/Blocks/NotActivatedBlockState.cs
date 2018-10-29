using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Blocks
{
    class NotActivatedBlockState : BlockState, IBlockState
    {
        private IBlock block;
        public override string StateCode
        {
            get
            {
                return "NACT";
            }
        }

        public NotActivatedBlockState(IBlock block)
        {
            this.block = block;
            this.block.BlockState = this;
            this.block.UpdateSprite();
        }

        public override void Bump()
        {
            block.BumpState = new BumpedBlockState(block);
        }

        public override void Activate()
        {
            block.BlockState = new ActivatedBlockState(block);
        }
    }
}
