using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0.Interfaces
{
    public interface IBlockState
    {
        void Activate();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet);
        void Update();
    }
}
