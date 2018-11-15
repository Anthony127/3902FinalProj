using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class FireBallExplodedSprite : Sprite, ISprite
    {
        public FireBallExplodedSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
                return new Rectangle(102, 81, 17, 17);
        }
    }
}
