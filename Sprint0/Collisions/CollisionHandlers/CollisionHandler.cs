using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Commands.CollisionCommands;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Mario.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Collisions.CollisionHandlers
{
    class CollisionHandler : ICollisionHandler
    {
        private Dictionary<Type, Type> commandDictionary;

        public CollisionHandler()
        {
            commandDictionary = new Dictionary<Type, Type>();
        }
        public void LoadCollisionResponses()
        {
            commandDictionary.Add(typeof(BrickBlockWithItem), typeof(MarioAndBrickBlockWithItemCollisionResponse));
            commandDictionary.Add(typeof(BrickBlockWithCoin), typeof(MarioAndBrickBlockWithItemCollisionResponse));
            commandDictionary.Add(typeof(BrickBlockWithStar), typeof(MarioAndBrickBlockWithItemCollisionResponse));
            commandDictionary.Add(typeof(BrickBlock), typeof(MarioAndBrickBlockCollisionResponse));
            commandDictionary.Add(typeof(QuestionBlock), typeof(MarioAndQuestionBlockCollisionResponse));
            commandDictionary.Add(typeof(QuestionBlockCoin), typeof(MarioAndQuestionBlockCollisionResponse));
            commandDictionary.Add(typeof(QuestionBlockStar), typeof(MarioAndQuestionBlockCollisionResponse));
            commandDictionary.Add(typeof(HiddenBlock), typeof(MarioAndHiddenBlockCollisionResponse));
            commandDictionary.Add(typeof(Koopa), typeof(MarioAndKoopaCollisionResponse));
            commandDictionary.Add(typeof(Goomba), typeof(MarioAndGoombaCollisionResponse));
            commandDictionary.Add(typeof(FireFlower), typeof(MarioAndFireFlowerCollisionResponse));
            commandDictionary.Add(typeof(SuperMushroom), typeof(MarioAndSuperMushroomCollisionResponse));
            commandDictionary.Add(typeof(Star), typeof(MarioAndStarCollisionResponse));
        }
        public void HandleCollision(ICollision collision)
        {
            ICommand command = null;
            HandleGenericObjectCollision(collision, command);
            HandleSpecificObjectCollision(collision, command);   
        }

        private void HandleGenericObjectCollision(ICollision collision, ICommand command)
        {
            if (collision.GetSecondEntity() is IBlock)
            {
                command = new MarioAndBlockCollisionResponse(collision);
                command.Execute();
            }
            else if (collision.GetSecondEntity() is IItem)
            {
                command = new MarioAndItemCollisionResponse(collision);
                command.Execute();
            }
            else if (collision.GetSecondEntity() is IEnemy)
            {
                command = new MarioAndEnemyCollisionResponse(collision);
                command.Execute();
            }
        }

        private void HandleSpecificObjectCollision(ICollision collision, ICommand command)
        {
            ICollision[] collisions = new ICollision[1] { collision };
            commandDictionary.TryGetValue(collision.GetSecondEntity().GetType(), out Type commandType);
            if (commandType != null)
            {
                ConstructorInfo[] constr = new ConstructorInfo[1];
                constr = commandType.GetConstructors();
                command = (ICommand)constr[0].Invoke(collisions);
                command.Execute();
            }
        }
    }
}
