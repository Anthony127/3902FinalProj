using Microsoft.Xna.Framework;
using Sprint0.Commands.CollisionCommands.GenericCollisions.EnemyWithBlock;
using Sprint0.Commands.CollisionCommands.GenericCollisions.PlayerWithItem;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.EnemyWithBlocks.Koopa;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.FireBallWithEnemies;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.BrickBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.HiddenBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.ItemBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWIthEnemies.Koopa;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithItems;
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
        private Dictionary<string, Type> collisionDictionary;
        private Dictionary<string, Type> genericDynamicWithBlockDictionary;
        private Dictionary<string, Type> genericPlayerWithEnemyDictionary;
        private Dictionary<string, Type> genericEnemyWithEnemyDictionary;

        public CollisionHandler()
        {
            collisionDictionary = new Dictionary<string, Type>();
            genericDynamicWithBlockDictionary = new Dictionary<string, Type>();
            genericPlayerWithEnemyDictionary = new Dictionary<string, Type>();
            genericEnemyWithEnemyDictionary = new Dictionary<string, Type>();

        }

        private string buildKey(Type firstEntity, Type secondEntity, CollisionConstants.Direction relativeDirection)
        {
            return firstEntity.ToString() + secondEntity.ToString() + relativeDirection.ToString();
        }

        public void LoadCollisionResponses()
        {
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(MarioWithBrickBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(MarioWithHiddenBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(MarioWithHiddenBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(MarioWithHiddenBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(MarioWithHiddenBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(MarioWithHiddenBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(MarioWithHiddenBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(MarioWithHiddenBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(MarioWithHiddenBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(MarioWithHiddenBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Down), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Up), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Left), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Right), typeof(FireBallWithEnemyCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Down), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Up), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Left), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Right), typeof(FireBallWithEnemyCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Down), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Up), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Left), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Right), typeof(GenericPlayerWithItemCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Down), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Up), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Left), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Right), typeof(GenericPlayerWithItemCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Down), typeof(MarioWithFireFlowerCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Up), typeof(MarioWithFireFlowerCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Left), typeof(MarioWithFireFlowerCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Right), typeof(MarioWithFireFlowerCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Down), typeof(MarioWithSuperMushroomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Up), typeof(MarioWithSuperMushroomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Left), typeof(MarioWithSuperMushroomCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Right), typeof(MarioWithSuperMushroomCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Down), typeof(MarioWithStarCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Up), typeof(MarioWithStarCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Left), typeof(MarioWithStarCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Right), typeof(MarioWithStarCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Down), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Up), typeof(MarioWithKoopaTopCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Left), typeof(MarioWithKoopaLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Right), typeof(MarioWithKoopaRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Koopa), CollisionConstants.Direction.Left), typeof(KoopaWithKoopaRightCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Koopa), CollisionConstants.Direction.Right), typeof(KoopaWithKoopaLeftCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Koopa), CollisionConstants.Direction.Left), typeof(GenericEnemyWithEnemyLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Koopa), CollisionConstants.Direction.Right), typeof(GenericEnemyWithEnemyRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Goomba), CollisionConstants.Direction.Left), typeof(GenericEnemyWithEnemyLeftCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Goomba), typeof(Goomba), CollisionConstants.Direction.Right), typeof(GenericEnemyWithEnemyRightCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Goomba), CollisionConstants.Direction.Left), typeof(KoopaWithEnemyRightCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(Koopa), typeof(Goomba), CollisionConstants.Direction.Right), typeof(KoopaWithEnemyLeftCollisionResponse));

            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Down), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Up), typeof(GenericPlayerWithEnemyPositiveCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Left), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));
            collisionDictionary.Add(buildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Right), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));

        }

        public void HandleCollision(ICollision collision)
        {
            ICommand command = null;
            ICollision[] collisions = new ICollision[1] { collision };
            Type commandType;
            if (collision.FirstEntity is IMario)
            {
                collisionDictionary.TryGetValue(buildKey(typeof(IMario), collision.SecondEntity.GetType(), collision.FirstEntityRelativePosition), out commandType);
            }
            else
            {
                collisionDictionary.TryGetValue(buildKey(collision.FirstEntity.GetType(), collision.SecondEntity.GetType(), collision.FirstEntityRelativePosition), out commandType);
            }
            if (commandType != null)
            {
                ConstructorInfo[] constr = new ConstructorInfo[1];
                constr = commandType.GetConstructors();
                command = (ICommand)constr[0].Invoke(new object[] { collision });
                command.Execute();
            }
        }

    }
}
