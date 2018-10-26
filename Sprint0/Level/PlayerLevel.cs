using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Collisions.CollisionDetectors;
using SuperPixelBrosGame.Collisions.CollisionHandlers;
using SuperPixelBrosGame.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Level
{
    class PlayerLevel : ILevel
    {
        private static PlayerLevel instance = new PlayerLevel();
        public IList<IEnemy> enemyArray;
        public IList<IBlock> blockArray;
        public IList<IItem> itemArray;
        public IList<IMario> playerArray;
        public IList<ICollidable> despawnList = new List<ICollidable>();
        private SuperPixelBrosGame game;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        private ICollisionHandler collisionHandler = new CollisionHandler();
        private ICollisionIterator collisionIterator = new CollisionIterator();

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

        public void LevelDraw(Camera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,camera.transform);
            spriteBatch.Draw(background, new Rectangle((int)Mario.Instance.GetLocation().X-391, 0, 800, 480), Color.White);
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
            Mario.Instance.Update();
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
            if (playerArray.Count > 0)
            {
                playerArray.Clear();
                playerArray.Add(Mario.Instance);
            }

            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), enemyArray.Cast<ICollidable>().ToList(), collisionHandler);
            
            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), itemArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(enemyArray.Cast<ICollidable>().ToList(), enemyArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(enemyArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(itemArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(itemArray.Cast<ICollidable>().ToList(), enemyArray.Cast<ICollidable>().ToList(), collisionHandler);

            foreach (ICollidable obj in despawnList)
            {
                obj.Despawn();
            }

            /*collision = collisionDetector.ScanForCollisions(Mario.Instance, enemyArray);
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
            }*/

        }

        public void TimeLevelOut()
        {
            if (game != null)
            {
                game.TimeLevelOut();
            }
        }

        public void SetBlockArray(IList<IBlock> array)
        {
            this.blockArray = array;
        }

        public void SetPlayerArray(IList<IMario> array)
        {
            this.playerArray = array;
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

        public void SetGame(SuperPixelBrosGame game)
        {
            this.game = game;
        }
    }
}
