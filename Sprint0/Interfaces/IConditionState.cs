using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface IConditionState
    {
        void TakeDamage();
        void PowerUp();
        string GetConditionCode();

    }
}
