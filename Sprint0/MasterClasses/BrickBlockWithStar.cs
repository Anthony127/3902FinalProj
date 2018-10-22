using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class BrickBlockWithStar : IBlock, ICollidable
    {
        private IBlockState blockState;
        private ISprite blockSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "BI";

        public BrickBlockWithStar()
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
            IItem star = new Star();
            star.SetLocation(new Vector2(this.location.X, this.location.Y - 16));
            Level.PlayerLevel.Instance.itemArray.Add(star);
        }

        public void Despawn()
        {
            PlayerLevel.Instance.blockArray.Remove(this);
        }
    }
}
