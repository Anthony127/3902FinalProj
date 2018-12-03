using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperPixelBrosGame.Sprites
{
    public class CostumeSprite : Sprite, ISprite
    {
        private readonly int COSTUME_SCALAR = 32;
        private int colId;
        protected int ColId {get => colId; set => colId = value;}
        public CostumeSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(Mario.Instance.RowId * SpriteUtility.Instance.MATRIX_UNIT, ColId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
        }
        protected override Rectangle GetDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, COSTUME_SCALAR * SIZE_SCALAR, COSTUME_SCALAR * SIZE_SCALAR);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            base.Draw(spriteBatch, location, SpriteUtility.Instance.ColorFromState(Mario.Instance.ConditionState));
        }
    }
}
