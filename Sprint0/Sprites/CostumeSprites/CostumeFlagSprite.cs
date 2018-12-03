using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class CostumeFlagSprite : Sprite, ISprite
    {
        private int colId = 19;
        public CostumeFlagSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, colId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
        }

        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 32 * SIZE_SCALAR, 32 * SIZE_SCALAR);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            base.Draw(spriteBatch, location, SpriteUtility.Instance.ColorFromState(Mario.Instance.ConditionState));
        }
    }
}