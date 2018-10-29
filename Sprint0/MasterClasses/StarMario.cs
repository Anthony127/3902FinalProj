using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Mario.Condition;
using SuperPixelBrosGame.States.Mario.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class StarMario : IMario, ICollidable, IPhysics
    {
        Mario mario;
        int timer = 1000;

        public IMovementState MovementState { get => mario.MovementState; set => mario.MovementState = value; }
        public IConditionState ConditionState { get => mario.ConditionState; set => mario.ConditionState = value; }
        public Vector2 Location { get => mario.Location; set => mario.Location = value; }
        public Rectangle Hitbox { get => mario.Hitbox; set => mario.Hitbox = value; }
        public Vector2 Velocity { get => mario.Velocity; set => mario.Velocity = value; }
        public Vector2 Friction { get => mario.Friction; set => mario.Friction = value; }

        public StarMario(Mario mario)
        {
            this.mario = mario;
        }

        public void CreateStarMario()
        {

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

        }
        public void PowerUp()
        {
            mario.PowerUp();
        }
        public void Idle()
        {
            mario.Idle();
        }

        public void UpdateSprite()
        {
            mario.UpdateSprite();
        }

        public void Despawn()
        {
            PlayerLevel.Instance.playerArray.Remove(this);
        }

        public void ThrowFireBall()
        {
            mario.ThrowFireBall();
        }
    }
}
