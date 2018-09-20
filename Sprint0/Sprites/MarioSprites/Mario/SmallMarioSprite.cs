﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.States.Mario;

namespace Sprint0.Sprites.MarioSprites.Mario
{
    class SmallMarioSprite : IMarioSprite, ISprite
    {
        public IMarioState State { get; set; }

        private Texture2D spriteSheet;

        public SmallMarioSprite(Texture2D texture)
        {
            spriteSheet = texture;
            State = new IdleSmallMarioRightState(this);
        }

        public void Update()
        {
            State.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, location, spriteSheet);
        }

        public void Jump()
        {
            State.Jump();
        }

        public void Crouch()
        {
            State.Crouch();
        }

        public void RunRight()
        {
            State.RunRight();
        }

        public void RunLeft()
        {
            State.RunLeft();
        }
    }
}
