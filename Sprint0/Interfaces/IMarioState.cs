using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{ }
    public interface IMarioState
    {
        string currentState;
        string powerUp;
        boolean isFacingRight;
        boolean isGrounded; // CASES NOT IMPLEMENTED
        boolean isHurt;
        boolean isJumpAttack; // CASES NOT IMPLEMENTED
        // ADD Sprite parameter    

    void NextState(string currentState, string buttonInput);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet);
        void Update();
    }
}