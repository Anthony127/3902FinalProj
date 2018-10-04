using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IMario
    {
        IMovementState GetMovementState();
        IConditionState GetConditionState();
        Vector2 GetLocation();
        Rectangle GetHitbox();
        void SetLocation(Vector2 location);
        void SetMovementState(IMovementState movement);
        void SetConditionState(IConditionState condition);
        void SetHitbox(Rectangle hitbox);
        void CreateStarMario();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Jump();
        void RunLeft();
        void RunRight();
        void Crouch();
        void TakeDamage();
        void PowerUp();
        void Idle();
       
    }
}
