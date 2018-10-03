using Microsoft.Xna.Framework.Graphics;
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
        IList<IItem> GetItemArray();
        void SetBlockArray(IList<IBlock> blockArray);
        void SetEnemyArray(IList<IEnemy> enemyArray);
        void SetItemArray(IList<IItem> itemArray);
        void SetSpriteBatch(SpriteBatch batch);
        void LevelUpdate();
        void LevelDraw();
        
    }
}
