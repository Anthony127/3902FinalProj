using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.States
{
    class NormalBrickBlockState : IBlockState
    {
        private BrickBlockSprite block;

        public NormalBrickBlockState(BrickBlockSprite block)
        {
            this.block = block;
        }

        public void Activate()
        {
            block.State = new ActivatedBrickBlockState(block);
        }

        public void Update()
        {
            //no -op
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Texture2D spriteSheet)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(290, 17, 16, 16);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(spriteSheet, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
