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
            id = "KP";
            UpdateSprite();
            hitbox = enemySprite.GetHitboxFromSprite(location);
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            hitbox = new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }
    }
}
