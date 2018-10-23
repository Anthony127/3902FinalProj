using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.MasterClasses
{
    class BumpedBlock : IBlock, ICollidable
    {
        private IBlock block;
        private ICollidable blockCollisions;
        private int frames = 10;

        public BumpedBlock(IBlock block)
        {
            this.block = block;
            blockCollisions = (ICollidable)block;
        }

        public void Activate()
        {
            block.Activate();
        }

        public void Bump()
        {
            
        }

        public void Despawn()
        {
            blockCollisions.Despawn();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            block.Draw(spriteBatch, new Vector2(location.X, location.Y - 5), color);
        }

        public IBlockState GetBlockState()
        {
            return block.GetBlockState();
        }

        public Rectangle GetHitbox()
        {
            return blockCollisions.GetHitbox();
        }

        public Vector2 GetLocation()
        {
            return blockCollisions.GetLocation();
        }

        public void SetBlockState(IBlockState state)
        {
            block.SetBlockState(state);
        }

        public void SetHitbox(Rectangle hitbox)
        {
            blockCollisions.SetHitbox(hitbox);
        }

        public void SetLocation(Vector2 location)
        {
            blockCollisions.SetLocation(location);
        }

        public void SpawnItem()
        {
            block.SpawnItem();
        }

        public void Update()
        {
            block.Update();
            frames--;
            if  (frames == 0)
            {
                PlayerLevel.Instance.despawnList.Add(this);
                PlayerLevel.Instance.blockArray.Add(block);
            }
        }
    }
}
