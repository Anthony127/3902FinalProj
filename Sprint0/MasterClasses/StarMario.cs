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
    class StarMario : IMario
    {
        IMario mario;
        
        public StarMario(IMario mario)
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
        public void Update()
        {
            mario.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            mario.Draw(spriteBatch, location, color);
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
            mario.TakeDamage();
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
