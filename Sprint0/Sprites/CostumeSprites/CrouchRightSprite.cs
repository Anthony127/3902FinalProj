using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;
using SuperPixelBrosGame.MasterClasses;

namespace SuperPixelBrosGame
{
    public class CrouchRightSprite : Sprite, ISprite
    {
        private int colId = 1;
        public CrouchRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, colId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
        }

        public override Rectangle GetHitboxFromSprite(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y + SourceRectangle.Width * SIZE_SCALAR, SourceRectangle.Width * SIZE_SCALAR, (SourceRectangle.Height / 2) * SIZE_SCALAR);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            base.Draw(spriteBatch, location, SpriteUtility.Instance.ColorFromState(Mario.Instance.ConditionState));
        }
    }
}