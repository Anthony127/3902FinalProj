using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies.Condition;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.MasterClasses;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame
{
    class Koopa : Enemy, IEnemy, ICollidable, IPhysics
    {

        public Koopa()
        {
            Id = "KP";
            UpdateSprite();
            Hitbox = EnemySprite.GetHitboxFromSprite(Location);
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            Hitbox = new Rectangle((int)Location.X, (int)Location.Y, 16, 16);
        }
    }
}
