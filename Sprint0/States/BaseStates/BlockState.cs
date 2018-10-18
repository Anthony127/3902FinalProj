using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.States.BaseStates
{
    abstract class BlockState : IBlockState
    {
        public virtual string StateCode
        {
            get
            {
                return "";
            }
        }
        public virtual void Activate() { }
    }
}
