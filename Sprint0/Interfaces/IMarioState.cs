﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface IMarioState
    { 
        void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet);
        void Update();
        void Jump();
        void Crouch();
        void RunRight();
        void RunLeft();
    }
}