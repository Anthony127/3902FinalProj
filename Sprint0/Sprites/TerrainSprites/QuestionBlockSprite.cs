using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.States;

namespace Sprint0
{
    public class QuestionBlockSprite : ISprite, IBlockSprite
    {
        public IBlockState State { get; set; }

        private Texture2D spriteSheet;

        public QuestionBlockSprite(Texture2D texture)
        {
            spriteSheet = texture;
            State = new NormalQuestionBlockState(this);
        }

        public void Activate()
        {
            State.Activate();
        }

        public void Update()
        {
            State.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, location, spriteSheet);
        }
    }
}