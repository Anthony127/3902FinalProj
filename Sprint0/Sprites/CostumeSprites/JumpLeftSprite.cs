using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Sprites;

namespace SuperPixelBrosGame
{
    public class JumpLeftSprite : Sprite, ISprite
    {
        private int colId = 32;
        public JumpLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, colId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            base.Draw(spriteBatch, location, SpriteUtility.Instance.ColorFromState(Mario.Instance.ConditionState));
        }
    }
}