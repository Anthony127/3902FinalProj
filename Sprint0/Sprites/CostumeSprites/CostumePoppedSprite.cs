using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumePoppedSprite : CostumeSprite, ISprite
    {
        private int colId1 = 25;
        private int colId2 = 26;
        private int colId3 = 27;
        public CostumePoppedSprite(Texture2D spriteSheet) : base(spriteSheet)
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
            if (CurrentFrame < 5 || (CurrentFrame < 20 && CurrentFrame > 16))
            {
                return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, colId1 * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
            }
            else if (CurrentFrame < 10 || (CurrentFrame < 25 && CurrentFrame > 21))
            {
                return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, colId2 * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
            }
            else
            {
                return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, colId3 * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
            }
        }
    }
}