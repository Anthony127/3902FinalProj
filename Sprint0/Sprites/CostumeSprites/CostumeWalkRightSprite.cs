using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Sprites;
using System.Threading;

namespace SuperPixelBrosGame
{
    public class CostumeWalkRightSprite : CostumeSprite, ISprite
    {
        private int colId1 = 3;
        private int colId2 = 2;
        private int colId3 = 4;
        public CostumeWalkRightSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
        }

        protected override Rectangle GetSourceRectangle()
        {
            if (CurrentFrame < 5 || (CurrentFrame>15 && CurrentFrame< 20))
            {
                return new Rectangle(colId1 * SpriteUtility.Instance.MATRIX_UNIT, RowId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
            }
            else if (CurrentFrame <10 || (CurrentFrame>20 && CurrentFrame<25))
            {
                return new Rectangle(colId2 * SpriteUtility.Instance.MATRIX_UNIT, RowId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
            }
            else
            {
                return new Rectangle(colId3 * SpriteUtility.Instance.MATRIX_UNIT, RowId * SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT, SpriteUtility.Instance.MATRIX_UNIT);
            }
        }
    }
}
