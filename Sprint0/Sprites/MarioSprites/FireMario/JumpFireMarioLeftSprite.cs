using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class JumpFireMarioLeftSprite : Sprite, ISprite
    {
        public JumpFireMarioLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(168, 474, 16, 32);
        }
    }
}