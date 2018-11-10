using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.CollisionCommands.SpecificCollisions.PlayerWIthEnemies.Koopa
{
    class MarioWithKoopaTopCollisionResponse : ICommand
    {
        private IMario firstEntity;
        private IEnemy secondEntity;
        private ICollision collision;

        public MarioWithKoopaTopCollisionResponse(ICollision collision)
        {
            firstEntity = (IMario)collision.FirstEntity;
            secondEntity = (IEnemy)collision.SecondEntity;
            this.collision = collision;
        }

        public void Execute()
        {
            ScoreKeeper.Instance.IncreaseScore();
            ScoreKeeper.Instance.IncMultiplier();
            if (firstEntity is StarMario)
            {
                secondEntity.PopOff();
                SoundFactory.Instance.PlaySoundEffect("SOUND_KICK");
            }
            firstEntity.Location = new Vector2(firstEntity.Location.X, firstEntity.Location.Y - collision.Overlap.Height);
            firstEntity.MovementState = new MarioRightJumpState(firstEntity);
            IPhysics secondEntityPhysics = (IPhysics)secondEntity;
            if (secondEntityPhysics.Velocity.X != 0)
            {
                secondEntityPhysics.Velocity = new Vector2(0, 0);
                SoundFactory.Instance.PlaySoundEffect("SOUND_STOMP");
            }
            else
            {
                secondEntityPhysics.Velocity = new Vector2((float)-2.5, 0);
                SoundFactory.Instance.PlaySoundEffect("SOUND_STOMP");
            }
            secondEntity.RunLeft();
            secondEntity.TakeDamage();
        }
    }
}
