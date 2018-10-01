using Sprint0.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Level
{
    class PlayerLevel : ILevel
    {
        private static PlayerLevel instance = new PlayerLevel();
        public IList<IEnemy> enemyArray;
        public IList<IBlock> blockArray;

        public static PlayerLevel Instance
        {
            get
            {
                return instance;
            }
        }

        public IList<IBlock> GetBlockArray()
        {
            return blockArray;
        }

        public IList<IEnemy> GetEnemyArray()
        {
            return enemyArray;
        }

        public void SetBlockArray(IList<IBlock> array)
        {
            this.blockArray = array;
        }

        public void SetEnemyArray(IList<IEnemy> array)
        {
            this.enemyArray = array;
        }
    }
}
