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
        private static readonly PlayerLevel instance = new PlayerLevel();
        private IList<IEnemy> enemyArray;
        private IList<IBlock> blockArray;
        private IList<IItem> itemArray;
        private IList<IMario> playerArray;
        private IList<IItem> removeArray = new List<IItem>();
        private readonly IList<ICollidable> despawnList = new List<ICollidable>();
        private SuperPixelBrosGame game;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        private Rectangle backgroundDestination;
        private ICollisionHandler collisionHandler = new CollisionHandler();
        private ICollisionIterator collisionIterator = new CollisionIterator();
        private IList<IBlock> blockCollisionsToCheck = new List<IBlock>();
        private IList<IItem> itemCollisionsToCheck = new List<IItem>();
        private IList<IEnemy> enemyCollisionsToCheck = new List<IEnemy>();

        public static PlayerLevel Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerLevel (){}

        public void TransitionState()
        {
            game.TransitionState();
        }

        public void VictoryState(IMario mario, FlagPole flagPole)
        {
            game.VictoryState(mario, flagPole);
        }

        public IList<IBlock> BlockArray { get => blockArray; set => blockArray = value; }
        public IList<IItem> ItemArray { get => itemArray; set => itemArray = value; }
        public IList<IEnemy> EnemyArray { get => enemyArray; set => enemyArray = value; }
        public IList<IMario> PlayerArray { get => playerArray; set => playerArray = value; }
        public IList<IItem> RemoveArray { get => removeArray; set => removeArray = value; }


        public IList<ICollidable> DespawnList { get => despawnList; }
        public SuperPixelBrosGame Game { get => game;  set => game = value; }
        public Texture2D Background { get => background; set => background = value; }
        public Rectangle BackgroundDestination { get => BackgroundDestination; set => backgroundDestination = value; }


        public void LoadCollisions()
        {
            collisionHandler.LoadCollisionResponses();
        }

        public void LevelDraw(ICamera levelCamera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, levelCamera.Transform);
            spriteBatch.Draw(background, backgroundDestination, Color.White);
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

        public void LevelUpdate(ICamera levelCamera)
        {
            
            Mario.Instance.Update();
            backgroundDestination = new Rectangle(levelCamera.Bounds.Location.X-400, levelCamera.Bounds.Location.Y, 800, 480);
            if (Mario.Instance.Location.Y > 600)
            {
                TimeLevelOut();
            }
            foreach (IEnemy enemy in enemyArray)
            {
            //we should change this to a camera paramter
                if ((enemy.Location.Y >= 0 && enemy.Location.Y <= 480) && (enemy.Location.X >= levelCamera.Bounds.Location.X - 440 && enemy.Location.X <= levelCamera.Bounds.Location.X + 440))
                {
                    enemy.Update();
                    enemyCollisionsToCheck.Add(enemy);
                }
            }
            foreach (IBlock block in blockArray)
            {

                if ((block.Location.Y >= 0 && block.Location.Y <= 480) && (block.Location.X >= levelCamera.Bounds.Location.X - 440 && block.Location.X <= levelCamera.Bounds.Location.X + 440))
                {
                    block.Update();
                    //blockCollisionsToCheck.Add(block);
                }
            }
            foreach (IItem item in itemArray)
            {
                if ((item.Location.Y >= 0 && item.Location.Y <= 480) && (item.Location.X >= levelCamera.Bounds.Location.X - 440 && item.Location.X <= levelCamera.Bounds.Location.X + 440))
                {
                    item.Update();
                    //itemCollisionsToCheck.Add(item);
                }
            }
            if (playerArray.Count > 0)
            {
                playerArray.Clear();
                playerArray.Add(Mario.Instance);
            }
            while (removeArray.Count > 0) {
                itemArray.Remove(removeArray[0]);
                removeArray.RemoveAt(0);
            }

            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), enemyCollisionsToCheck.Cast<ICollidable>().ToList(), collisionHandler);

            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), itemArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(enemyCollisionsToCheck.Cast<ICollidable>().ToList(), enemyCollisionsToCheck.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(enemyCollisionsToCheck.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(itemArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(itemArray.Cast<ICollidable>().ToList(), enemyCollisionsToCheck.Cast<ICollidable>().ToList(), collisionHandler);

            enemyCollisionsToCheck.Clear();
            blockCollisionsToCheck.Clear();
            itemCollisionsToCheck.Clear();

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
