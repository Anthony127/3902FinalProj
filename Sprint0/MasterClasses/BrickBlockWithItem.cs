using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class BrickBlockWithItem : IBlock, ICollidable
    {
        private IBlockState blockState;
        private ISprite blockSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "BI";

        public BrickBlockWithItem()
        {
            blockState = new NotActivatedBlockState(this);
            location = new Vector2(0, 0);
            hitbox = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            UpdateSprite();
        }

        public void Update()
        {
            blockSprite.Update();
            hitbox = new Rectangle((int)location.X, (int)location.Y, hitbox.Width, hitbox.Height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            blockSprite.Draw(spriteBatch, location, color);
        }

        public IBlockState GetBlockState()
        {
            return blockState;
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        public void SetBlockState(IBlockState state)
        {
            blockState = state;
        }

        public void SetHitbox(Rectangle hitbox)
        {
            this.hitbox = hitbox;
        }

        public void Activate()
        {
            blockState.Activate();
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            blockSprite = TerrainSpriteFactory.Instance.CreateSprite(blockState, ID);
        }
    }
}
