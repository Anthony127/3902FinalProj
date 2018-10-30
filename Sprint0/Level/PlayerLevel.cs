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
    class PlayerLevel
    {
        private static PlayerLevel instance = new PlayerLevel();
        private IList<IEnemy> enemyArray;
        private IList<IBlock> blockArray;
        private IList<IItem> itemArray;
        private IList<IMario> playerArray;
        private IList<ICollidable> despawnList = new List<ICollidable>();
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

        public IList<IBlock> BlockArray { get => blockArray; set => blockArray = value; }
        public IList<IItem> ItemArray { get => itemArray; set => itemArray = value; }
        public IList<IEnemy> EnemyArray { get => enemyArray; set => enemyArray = value; }
        public IList<IMario> PlayerArray { get => playerArray; set => playerArray = value; }
        public IList<ICollidable> DespawnList { get => despawnList; }
        public SuperPixelBrosGame Game { set => game = value; }
        public Texture2D Background {set => background = value; }

        public void LoadCollisions()
        {
            collisionHandler.LoadCollisionResponses();
        }

        public void LevelDraw(ICamera levelCamera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, levelCamera.Transform);
            spriteBatch.Draw(background, new Rectangle((int)Mario.Instance.Location.X-391, 0, 800, 480), Color.White);
            foreach (IEnemy enemy in enemyArray){
                enemy.Draw(spriteBatch, enemy.Location, Color.White);
            }
            foreach (IBlock block in blockArray) {
                block.Draw(spriteBatch, block.Location, Color.White);
            }
            foreach (IItem item in itemArray)
            {
                item.Draw(spriteBatch, item.Location, Color.White);
            }

            Mario.Instance.Draw(spriteBatch, Mario.Instance.Location, Color.White);
            spriteBatch.End();
        }

        public void LevelUpdate()
        {
            Mario.Instance.Update();
            if (Mario.Instance.Location.Y > 600)
            {
                TimeLevelOut();
            }
            foreach (IEnemy enemy in enemyArray)
            {
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
        }

        public void TimeLevelOut()
        {
                game.TimeLevelOut();
        }

        public void SetSpriteBatch(SpriteBatch batch)
        {
            this.spriteBatch = batch;
        }
    }
}
