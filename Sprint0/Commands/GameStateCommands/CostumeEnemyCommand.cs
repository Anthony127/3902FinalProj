using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    public class CostumeEnemyCommand : ICommand
    {


        public CostumeEnemyCommand()
        {
        }

        public void Execute()
        {
            EnemySpriteFactory.Instance.EnableCostumes = !EnemySpriteFactory.Instance.EnableCostumes;
            foreach(IEnemy enemy in PlayerLevel.Instance.EnemyArray)
            {
                enemy.UpdateSprite();
            }
        }

    }
}

