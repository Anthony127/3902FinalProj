﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.States
{
    class IdleFireMarioState : IMarioState
    {

        string currentState;
        string powerUp;
        boolean isFacingRight;
        boolean isGrounded; // CASES NOT IMPLEMENTED
        boolean isHurt;
        boolean isJumpAttack; // CASES NOT IMPLEMENTED
        // ADD Sprite parameter


        public void IdleFireMarioState()
        {
            this.currentState = "IDLE";
            this.powerUp = "FIRE_FLOWER";
            this.isFacingRight = true; // Default is facing right
            this.isGrounded = true;
            this.isHurt = false;
            this.isJumpAttack = false;
            // ADD Sprite parameter
        }


        public void NextState(string buttonInput, string currentState, string powerUp, boolean isFacingRight, boolean isGrounded, boolean isJumpAttack)
        {
            if (isHurt)
            {
                // no-op
                // TO-DO: Implement SmallMario transition (Japanese ver.) OR implement Mario transition (International ver.).
            }
            else if (powerUp != null)
            {
                switch (powerUp)
                {
                    case "FIRE_FLOWER":
                        // no-op
                        // TO-DO: Implement FireMario transition.
                        break;

                    default:
                        // no-op
                        // DO NOTHING
                        break;

                }
            }
            else
            {
                switch (buttonInput) // "UP" not implemented
                {
                    case "LEFT":
                        // TRANSITION to WALK (LEFT)
                        this.currentState = "WALK";
                        this.isFacingRight = false;
                        break;

                    case "RIGHT":
                        // TRANSITION to WALK (RIGHT)
                        this.currentState = "RIGHT";
                        this.isFacingRight = true;
                        break;

                    case "JUMP":
                        // TRANSITION to JUMP
                        this.currentState = "JUMP";
                        break;

                    case "DOWN":
                        // TRANSITION TO CROUCH
                        this.currentState = "CROUCH";
                        break;

                    // CASE: NO INPUT
                    default:
                        // no-op
                        // DO NOTHING
                        break;

                }
            }


        }

        public void Update()
        {
            // no-op
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            Rectangle sourceRectangle;
            sourceRectangle destinationRectangle;

            // sourceRectangle = new Rectangle();
            destinationRectangle = new sourceRectangle((int)location.X, (int)location.Y, 16, 16);

            spriteBatch.begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

    }
}
