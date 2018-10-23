using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Level
{
    interface ILevel
    {
        IList<IBlock> GetBlockArray();
        IList<IEnemy> GetEnemyArray();
        IList<IItem> GetItemArray();
        Texture2D GetBackground();
        void SetBlockArray(IList<IBlock> blockArray);
        void SetEnemyArray(IList<IEnemy> enemyArray);
        void SetItemArray(IList<IItem> itemArray);
        void SetBackground(Texture2D background);
        void SetSpriteBatch(SpriteBatch batch);
        void LevelUpdate();
        void LevelDraw(Camera camera);
        void LoadCollisions();
        
    }
}
