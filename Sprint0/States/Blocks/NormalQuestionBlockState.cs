using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.States
{
    class NormalQuestionBlockState : IBlockState
    {
        private QuestionBlockSprite block;
        private int currentFrame;
        private int totalFrames;

        public NormalQuestionBlockState(QuestionBlockSprite block)
        {
            this.block = block;
            currentFrame = 0;
            totalFrames = 30;
        }

        public void Activate()
        {
            block.State = new ActivatedQuestionBlockState(block);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (currentFrame < 8)
            {
                sourceRectangle = new Rectangle(17, 17, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            }
            else if (currentFrame > 8 && currentFrame < 15)
            {
                sourceRectangle = new Rectangle(34, 17, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            }
            else if (currentFrame > 15 && currentFrame < 23)
            {
                sourceRectangle = new Rectangle(51, 17, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(68, 17, 16, 16);
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}