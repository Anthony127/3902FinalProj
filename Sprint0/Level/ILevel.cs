using Sprint0.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Level
{
    interface ILevel
    {
        IList<IBlock> GetBlockArray();
        IList<IEnemy> GetEnemyArray();
        void SetBlockArray(IList<IBlock> blockArray);
        void SetEnemyArray(IList<IEnemy> enemyArray);
    }
}
