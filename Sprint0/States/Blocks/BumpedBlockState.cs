﻿using Sprint0.States.BaseStates;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.States.Blocks
{
    class BumpedBlockState : BlockState, IBlockState
    {
        private IBlock block;

        public override string StateCode
        {
            get
            {
                return "NACT";
            }
        }

        public BumpedBlockState(IBlock block)
        {
            this.block = block;
            this.block.BumpTimer--;
            this.block.UpdateSprite();
        }
    }
}