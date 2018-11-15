using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class KoopaPoppedSprite : Sprite, ISprite
    {
        public KoopaPoppedSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            SourceRectangle = GetSourceRectangle();
            Rectangle destinationRectangle = GetDestinationRectangle(location);
            spriteBatch.Draw(SpriteSheet, destinationRectangle, SourceRectangle, color, MathHelper.Pi, new Vector2(SourceRectangle.Width / 2, SourceRectangle.Height / 2), SpriteEffects.None, 0);
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 15)
            {
                return new Rectangle(132, 0, 16, 27);
            }
            else
            {
                return new Rectangle(92, 0, 16, 27);
            }
        }
    }
}