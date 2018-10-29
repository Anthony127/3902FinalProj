using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class BrickBlock : IBlock, ICollidable
    {
        private IBlockState blockState;
        private ISprite blockSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "BB";
        private int bumpTimer = 6;

        int IBlock.BumpTimer { get => bumpTimer; set => bumpTimer = value; }
        public IBlockState BumpState { get; set; }

        public BrickBlock()
        {
            blockState = new NotActivatedBlockState(this);
            location = new Vector2(0, 0);
            UpdateSprite();
            hitbox = blockSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Update()
        {
            blockSprite.Update();
            hitbox = blockSprite.GetHitboxFromSprite(GetLocation());
            if (bumpTimer == 0)
            {
                bumpTimer = 6;
                BumpState = null;
            }
            else if (bumpTimer < 6)
            {
                bumpTimer--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (BumpState is BumpedBlockState)
            {
                blockSprite.Draw(spriteBatch, new Vector2(location.X, location.Y - 6), color);
            }
            else
            {
                blockSprite.Draw(spriteBatch, location, color);
            }
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

        public void SpawnItem()
        {
        }

        public void Despawn()
        {
            PlayerLevel.Instance.blockArray.Remove(this);
        }

        public void Bump()
        {
            blockState.Bump();
        }
    }
}
