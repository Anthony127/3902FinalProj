using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface IMarioSprite
    {
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Update();
        void Jump();
        void Crouch();
        void RunRight();
        void RunLeft();
    }
}
