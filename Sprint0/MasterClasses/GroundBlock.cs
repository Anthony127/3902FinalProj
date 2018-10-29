using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class GroundBlock : IBlock, ICollidable
    {
        private IBlockState blockState;
        private ISprite blockSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "GB";
        private int bumpTimer = 25;

        int IBlock.BumpTimer { get => bumpTimer; set => bumpTimer = value; }
        public IBlockState BumpState { get; set; }

        public GroundBlock()
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