using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Sprites;
using System.Threading;

namespace SuperPixelBrosGame
{
    public class CostumeWalkLeftSprite : CostumeSprite, ISprite
    {
        private int colId1 = 25;
        private int colId2 = 26;
        private int colId3 = 27;
        public CostumeWalkLeftSprite(Texture2D spriteSheet) : base(spriteSheet)
        {
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
