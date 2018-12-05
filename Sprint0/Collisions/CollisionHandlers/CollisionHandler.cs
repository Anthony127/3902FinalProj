using Microsoft.Xna.Framework;
using Sprint0.Commands.CollisionCommands.GenericCollisions.EnemyWithBlock;
using Sprint0.Commands.CollisionCommands.GenericCollisions.EnemyWithEnemy;
using Sprint0.Commands.CollisionCommands.GenericCollisions.PlayerWithItem;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.EnemyWithBlocks.Generic;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.EnemyWithBlocks.Koopa;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.FireBallWithEnemies;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.ItemsWithBlocks;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.ItemsWithBlocks.Fireballs;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.BrickBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.HiddenBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithBlocks.ItemBlock;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWIthEnemies.Koopa;
using Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWithItems;
using SuperPixelBrosGame.Collisions.Collisions;
using SuperPixelBrosGame.Commands.CollisionCommands;
using SuperPixelBrosGame.Commands.CollisionCommands.SpecificCollisions.MarioWithFlag;
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

        public CollisionHandler()
        {
            collisionDictionary = new Dictionary<string, Type>();

        }

        private static string BuildKey(Type firstEntity, Type secondEntity, CollisionConstants.Direction relativeDirection)
        {
            return firstEntity.ToString() + secondEntity.ToString() + relativeDirection.ToString();
        }

        public void LoadCollisionResponses()
        {
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockEmpty), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockEmpty), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockEmpty), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockEmpty), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(MarioWithBrickBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(MarioWithHiddenBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(MarioWithHiddenBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(MarioWithHiddenBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Pipe), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(PipeBottom), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(PipeBottom), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(PipeBottom), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(PipeBottom), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(MarioWithWarpPipeTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(MarioWithHiddenBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(MarioWithHiddenBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(MarioWithHiddenBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Pipe), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(PipeBottom), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(PipeBottom), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(PipeBottom), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(PipeBottom), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(MarioWithHiddenBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(MarioWithHiddenBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(MarioWithHiddenBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Pipe), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(PipeBottom), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(PipeBottom), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(PipeBottom), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(PipeBottom), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(BrickBlockEmpty), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockEmpty), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockEmpty), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(BrickBlockEmpty), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(Pipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithItem), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithCoin), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockWithStar), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockEmpty), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockEmpty), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(BrickBlockEmpty), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockEmpty), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockCoin), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(QuestionBlockStar), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(HiddenBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(GroundBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UsedBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(UnbreakableBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Pipe), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(WarpPipe), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(WarpPipe), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(WarpPipe), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(WarpPipe), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Down), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Up), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Left), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Koopa), CollisionConstants.Direction.Right), typeof(FireBallWithEnemyCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Down), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Up), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Left), typeof(FireBallWithEnemyCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(Goomba), CollisionConstants.Direction.Right), typeof(FireBallWithEnemyCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Down), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Up), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Left), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(OneUpMushroom), CollisionConstants.Direction.Right), typeof(GenericPlayerWithItemCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Down), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Up), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Left), typeof(GenericPlayerWithItemCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Coin), CollisionConstants.Direction.Right), typeof(GenericPlayerWithItemCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Down), typeof(MarioWithFireFlowerCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Up), typeof(MarioWithFireFlowerCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Left), typeof(MarioWithFireFlowerCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FireFlower), CollisionConstants.Direction.Right), typeof(MarioWithFireFlowerCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Down), typeof(MarioWithSuperMushroomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Up), typeof(MarioWithSuperMushroomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Left), typeof(MarioWithSuperMushroomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(SuperMushroom), CollisionConstants.Direction.Right), typeof(MarioWithSuperMushroomCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Down), typeof(MarioWithStarCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Up), typeof(MarioWithStarCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Left), typeof(MarioWithStarCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Star), CollisionConstants.Direction.Right), typeof(MarioWithStarCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Down), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Up), typeof(MarioWithKoopaTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Left), typeof(MarioWithKoopaLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Koopa), CollisionConstants.Direction.Right), typeof(MarioWithKoopaRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Koopa), CollisionConstants.Direction.Left), typeof(KoopaWithKoopaRightCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Koopa), CollisionConstants.Direction.Right), typeof(KoopaWithKoopaLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Koopa), CollisionConstants.Direction.Up), typeof(GenericEnemyWithEnemyTopCollisionResponse));


            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Koopa), CollisionConstants.Direction.Left), typeof(GenericEnemyWithEnemyLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Koopa), CollisionConstants.Direction.Right), typeof(GenericEnemyWithEnemyRightCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Koopa), CollisionConstants.Direction.Up), typeof(GenericEnemyWithEnemyTopCollisionResponse));


            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Goomba), CollisionConstants.Direction.Left), typeof(GenericEnemyWithEnemyLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Goomba), CollisionConstants.Direction.Right), typeof(GenericEnemyWithEnemyRightCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(Goomba), CollisionConstants.Direction.Up), typeof(GenericEnemyWithEnemyTopCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Goomba), CollisionConstants.Direction.Left), typeof(KoopaWithEnemyLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Goomba), CollisionConstants.Direction.Right), typeof(KoopaWithEnemyRightCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(Goomba), CollisionConstants.Direction.Up), typeof(GenericEnemyWithEnemyTopCollisionResponse));


            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Down), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Up), typeof(GenericPlayerWithEnemyPositiveCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Left), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(Goomba), CollisionConstants.Direction.Right), typeof(GenericPlayerWithEnemyNegativeCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FlagPole), CollisionConstants.Direction.Down), typeof(MarioWithFlagCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FlagPole), CollisionConstants.Direction.Up), typeof(MarioWithFlagCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FlagPole), CollisionConstants.Direction.Left), typeof(MarioWithFlagCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(FlagPole), CollisionConstants.Direction.Right), typeof(MarioWithFlagCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(MarioWithItemBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(GenericDynamicWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(GenericDynamicWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(IMario), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(GenericDynamicWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(FireBallWithBlockHorizontalCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(FireBall), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(FireBallWithBlockHorizontalCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Star), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(BouncingItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Star), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(OneUpMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(ItemWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(ItemWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(SuperMushroom), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(ItemWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Goomba), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(EnemyBlock), CollisionConstants.Direction.Down), typeof(GenericDynamicWithBlockBottomCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(EnemyBlock), CollisionConstants.Direction.Up), typeof(EnemyWithBlockTopCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(EnemyBlock), CollisionConstants.Direction.Left), typeof(EnemyWithBlockLeftCollisionResponse));
            collisionDictionary.Add(BuildKey(typeof(Koopa), typeof(EnemyBlock), CollisionConstants.Direction.Right), typeof(EnemyWithBlockRightCollisionResponse));

        }

        public void HandleCollision(ICollision collision)
        {
            ICommand command = null;
            Type commandType;
            if (collision.FirstEntity is IMario)
            {
                collisionDictionary.TryGetValue(BuildKey(typeof(IMario), collision.SecondEntity.GetType(), collision.FirstEntityRelativePosition), out commandType);
            }
            else
            {
                collisionDictionary.TryGetValue(BuildKey(collision.FirstEntity.GetType(), collision.SecondEntity.GetType(), collision.FirstEntityRelativePosition), out commandType);
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
