﻿using Microsoft.Xna.Framework;
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
        IMovementState MovementState { get; set; }
        IConditionState ConditionState { get; set; }
        int RowId { get; set; }
        Vector2 Location { get; set; }
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
        void UpdateSprite();
        void Run();
        void TransitionStatePositive();
        void TransitionStateNegative();
        void ThrowFireBall();
       
    }
}
