using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collisions.CollisionDetectors;
using Sprint0.Collisions.CollisionHandlers;
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
        private SpriteBatch spriteBatch;
        private ICollisionHandler collisionHandler = new CollisionHandler();
        private ICollisionDetector collisionDetector = new CollisionDetector();

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

        public void LevelDraw()
        {
            foreach(IEnemy enemy in enemyArray){
                enemy.Draw(spriteBatch, enemy.GetLocation());
            }
            foreach (IBlock block in blockArray) {
                block.Draw(spriteBatch, block.GetLocation());
            }

            Mario.Instance.Draw(spriteBatch, Mario.Instance.GetLocation());
        }

        public void LevelUpdate()
        {
            ICollision collision = null;
            foreach (IEnemy enemy in enemyArray) {
                enemy.Update();
            }
            foreach(IBlock block in blockArray)
            {
                block.Update();
            }
            collision = collisionDetector.ScanForCollisions(Mario.Instance, enemyArray);
            if (collision != null)
            {
                collisionHandler.HandleCollision(collision);
            }
            //CollisionDetector.Instance.ScanForCollisions(Mario.Instance, itemArray);
            //if (collision != null)
            //{
            //    collisionHandler.HandleCollision(collision);
            //}
            collision = collisionDetector.ScanForCollisions(Mario.Instance, blockArray);
            if (collision != null)
            {
                collisionHandler.HandleCollision(collision);
            }

            Mario.Instance.Update();
        }

        public void SetBlockArray(IList<IBlock> array)
        {
            this.blockArray = array;
        }

        public void SetEnemyArray(IList<IEnemy> array)
        {
            this.enemyArray = array;
        }

        public void SetSpriteBatch(SpriteBatch batch)
        {
            this.spriteBatch = batch;
        }
    }
}
