using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class QuestionBlockSprite : Sprite, ISprite
    {
        public QuestionBlockSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 8)
            {
                return new Rectangle(17, 17, 16, 16);
            }
            else if (CurrentFrame > 8 && CurrentFrame < 15)
            {
                return new Rectangle(34, 17, 16, 16);
            }
            else if (CurrentFrame > 15 && CurrentFrame < 23)
            {
                return new Rectangle(51, 17, 16, 16);
            }
            else
            {
                return new Rectangle(68, 17, 16, 16);
            }
        }
    }
}
