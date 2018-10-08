using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.States.Mario.Condition;
using Sprint0.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class StarMario : IMario, ICollidable
    {
        Mario mario;
        int timer = 1000;
        
        public StarMario(Mario mario)
        {
            this.mario = mario;
        }
        public IMovementState GetMovementState()
        {
            return mario.GetMovementState();
        }
        public IConditionState GetConditionState()
        {
            return mario.GetConditionState();
        }
        public Vector2 GetLocation()
        {
            return mario.GetLocation();
        }
        public Rectangle GetHitbox()
        {
            return mario.GetHitbox();
        }
        public void SetLocation(Vector2 location)
        {
            mario.SetLocation(location);
        }
        public void SetMovementState(IMovementState movement)
        {
            mario.SetMovementState(movement);
        }
        public void SetConditionState(IConditionState condition)
        {
            mario.SetConditionState(condition);
        }
        public void SetHitbox(Rectangle hitbox)
        {
            mario.SetHitbox(hitbox);
        }
        public void CreateStarMario()
        {
            // no-op
        }

        public void UnloadStarMario()
        {
            mario.UnloadStarMario();
        }
        public void Update()
        {
            timer--;
            if (timer <= 1)
            {
                mario.UnloadStarMario();
            }
            mario.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (timer <= 1)
            {
                mario.Draw(spriteBatch, location, Color.White);
            }
            else
            {
                if ((timer % 60) < 10)
                {
                    mario.Draw(spriteBatch, location, Color.Yellow);
                }
                else if ((timer % 60) < 20)
                {
                    mario.Draw(spriteBatch, location, Color.Purple);
                }
                else if ((timer % 60) < 30)
                {
                    mario.Draw(spriteBatch, location, Color.Red);
                }
                else if ((timer % 60) < 40)
                {
                    mario.Draw(spriteBatch, location, Color.Green);
                }
                else if ((timer % 60) < 50)
                {
                    mario.Draw(spriteBatch, location, Color.Orange);
                }
                else
                {
                    mario.Draw(spriteBatch, location, Color.Azure);
                }
            } 
        }
        public void Jump()
        {
            mario.Jump();
        }
        public void RunLeft()
        {
            mario.RunLeft();
        }
        public void RunRight()
        {
            mario.RunRight();
        }
        public void Crouch()
        {
            mario.Crouch();
        }
        public void TakeDamage()
        {
            //no-op
        }
        public void PowerUp()
        {
            mario.PowerUp();
        }
        public void Idle()
        {
            mario.Idle();
        }


    }
}
