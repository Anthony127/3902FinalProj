using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface IMario
    {
        IMovementState GetMovementState();
        IConditionState GetConditionState();
        Vector2 GetLocation();
        void SetLocation(Vector2 location);
        void SetMovementState(IMovementState movement);
        void SetConditionState(IConditionState condition);
        void CreateStarMario();
        void UnloadStarMario();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Jump();
        void RunLeft();
        void RunRight();
        void Crouch();
        void TakeDamage();
        void PowerUp();
        void Idle();
       
    }
}
