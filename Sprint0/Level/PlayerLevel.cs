using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Collisions.CollisionDetectors;
using SuperPixelBrosGame.Collisions.CollisionHandlers;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Mario.Condition;
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
        private IList<ISprite> scoreArray = new List<ISprite>();
        private IList<ISprite> scoresToDelete = new List<ISprite>();
        private readonly IList<ICollidable> despawnList = new List<ICollidable>();
        private SuperPixelBrosGame game;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        private Rectangle backgroundDestination;
        private ICollisionHandler collisionHandler = new CollisionHandler();
        private ICollisionIterator collisionIterator = new CollisionIterator();
        private IList<IEnemy> enemyCollisionsToCheck = new List<IEnemy>();

        private int SCREENWIDTH = 800;
        private int SCREENHEIGHT = 480;
        private int FALLDEATHLINE = 600;
        private int SCREENCUTOFF = 440;

        public static PlayerLevel Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerLevel (){}


        public void Warp(IMario mario, Vector2 location)
        {
            game.Warp(mario, location);
        }
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
        public IList<ISprite> ScoreArray { get => scoreArray; }
        public IList<ISprite> ScoresToDelete { get => scoresToDelete; }


        public IList<ICollidable> DespawnList { get => despawnList; }
        public SuperPixelBrosGame Game { get => game;  set => game = value; }
        public Texture2D Background { set => background = value; }
        public Rectangle BackgroundDestination {set => backgroundDestination = value; }


        public void LoadCollisions()
        {
            collisionHandler.LoadCollisionResponses();
        }

        public void LevelDraw(ICamera levelCamera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, levelCamera.Transform);
            spriteBatch.Draw(background, backgroundDestination, Color.White);
            Mario.Instance.Draw(spriteBatch, Mario.Instance.Location, Color.White);
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
            foreach (ISprite score in scoreArray)
            {
                score.Draw(spriteBatch, new Vector2(0, 0), Color.White);
            }

            HUD.Instance.Draw(spriteBatch, backgroundDestination);

            spriteBatch.End();
        }

        public void LevelUpdate(ICamera levelCamera)
        {
            
            Mario.Instance.Update();
            backgroundDestination = new Rectangle(levelCamera.Bounds.Location.X-SCREENWIDTH/2, levelCamera.Bounds.Location.Y, SCREENWIDTH, SCREENHEIGHT);
            if (Mario.Instance.Location.Y > FALLDEATHLINE && !(Mario.Instance.ConditionState is DeadMarioState) || ScoreKeeper.Instance.Time < 2)
            {
                ICommand command = new KillMarioCommand(Mario.Instance);
                command.Execute();
            }
            foreach (IEnemy enemy in enemyArray)
            {
                if ((enemy.Location.Y >= 0 && enemy.Location.Y <= SCREENHEIGHT) && (enemy.Location.X >= levelCamera.Bounds.Location.X - SCREENCUTOFF && enemy.Location.X <= levelCamera.Bounds.Location.X + SCREENCUTOFF))
                {
                    enemy.Update();
                    enemyCollisionsToCheck.Add(enemy);
                }
            }
            foreach (IBlock block in blockArray)
            {

                if ((block.Location.Y >= 0 && block.Location.Y <= SCREENHEIGHT) && (block.Location.X >= levelCamera.Bounds.Location.X - SCREENCUTOFF && block.Location.X <= levelCamera.Bounds.Location.X + SCREENCUTOFF))
                {
                    block.Update();
                }
            }
            foreach (IItem item in itemArray)
            {
                if ((item.Location.Y >= 0 && item.Location.Y <= SCREENHEIGHT) && (item.Location.X >= levelCamera.Bounds.Location.X - SCREENCUTOFF && item.Location.X <= levelCamera.Bounds.Location.X + SCREENCUTOFF))
                {
                    item.Update();
                }
            }
            foreach (ISprite score in scoreArray)
            {
                score.Update();
            }
            if (playerArray.Count > 0)
            {
                playerArray.Clear();
                playerArray.Add(Mario.Instance);
            }

            CheckCollisions();
            DespawnObjects();


            ScoreKeeper.Instance.DecrementTime();
        }

        public void TimeLevelOut()
        {
                game.TimeLevelOut();
        }

        private void CheckCollisions()
        {
            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), enemyCollisionsToCheck.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), itemArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(enemyCollisionsToCheck.Cast<ICollidable>().ToList(), enemyCollisionsToCheck.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(enemyCollisionsToCheck.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(playerArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(itemArray.Cast<ICollidable>().ToList(), blockArray.Cast<ICollidable>().ToList(), collisionHandler);
            collisionIterator.ProcessCollisions(itemArray.Cast<ICollidable>().ToList(), enemyCollisionsToCheck.Cast<ICollidable>().ToList(), collisionHandler);

            enemyCollisionsToCheck.Clear();
        }

        private void DespawnObjects()
        {
            while (scoresToDelete.Count > 0)
            {
                scoreArray.Remove(scoresToDelete[0]);
                scoresToDelete.RemoveAt(0);
            }
            foreach (ICollidable obj in despawnList)
            {
                obj.Despawn();
            }
        }

        public void SetSpriteBatch(SpriteBatch batch)
        {
            this.spriteBatch = batch;
        }
    }
}
