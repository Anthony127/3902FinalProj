using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface IMarioState
    { 
        void NextState(string currentState, string buttonInput);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet);
        void Update();
    }
}