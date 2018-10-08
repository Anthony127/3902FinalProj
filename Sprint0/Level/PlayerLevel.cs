using Microsoft.Xna.Framework;
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
        public IList<IItem> itemArray;
        private SpriteBatch spriteBatch;
        private Texture2D background;
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

        public IList<IItem> GetItemArray()
        {
            return itemArray;
        }
        public Texture2D GetBackground()
        {
            return background;
        }

        public void LoadCollisions()
        {
            collisionHandler.LoadCollisionResponses();
        }

        public void LevelDraw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            foreach (IEnemy enemy in enemyArray){
                enemy.Draw(spriteBatch, enemy.GetLocation(), Color.White);
            }
            foreach (IBlock block in blockArray) {
                block.Draw(spriteBatch, block.GetLocation(), Color.White);
            }
            foreach (IItem item in itemArray)
            {
                item.Draw(spriteBatch, item.GetLocation(), Color.White);
            }

            Mario.Instance.Draw(spriteBatch, Mario.Instance.GetLocation(), Color.White);
            spriteBatch.End();
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
            foreach(IItem item in itemArray)
            {
                item.Update();
            }
            collision = collisionDetector.ScanForCollisions(Mario.Instance, enemyArray);
            if (collision != null)
            {
                collisionHandler.HandleCollision(collision);
            }
            collision = collisionDetector.ScanForCollisions(Mario.Instance, itemArray);
            if (collision != null)
            {
                collisionHandler.HandleCollision(collision);
            }
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

        public void SetItemArray(IList<IItem> array)
        {
            this.itemArray = array;
        }

        public void SetBackground(Texture2D image)
        {
            this.background = image;
        }

        public void SetSpriteBatch(SpriteBatch batch)
        {
            this.spriteBatch = batch;
        }
    }
}
