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
        void SetMovementState(IMovementState movement);
        void SetConditionState(IConditionState condition);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Jump();
        void RunLeft();
        void RunRight();
        void Crouch();
        void TakeDamage();
        void PowerUp();
       
    }
}
