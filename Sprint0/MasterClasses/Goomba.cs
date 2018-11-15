using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Enemies.Condition;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class Goomba : Enemy, IEnemy, ICollidable, IPhysics
    {
        private int despawnTimer;

        public Goomba()
        {
            despawnTimer = 40;
        }

        public override void Update()
        {
            base.Update();
            if (despawnTimer == 0)
            {
                PlayerLevel.Instance.DespawnList.Add(this);
            }
            else if (despawnTimer < 40)
            {
                despawnTimer--;
            }
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            despawnTimer--;
        }
    }
}
