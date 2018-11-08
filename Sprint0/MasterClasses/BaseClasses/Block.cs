using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.States.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.MasterClasses.BaseClasses
{
    public abstract class Block : IBlock, ICollidable
    {
        private IBlockState blockState;
        private IBlockState bumpState;
        private Vector2 location;
        private Rectangle hitbox;
        private int bumpTimer = 6;
        private int timeout = 5;
        private ISprite blockSprite;
        private string id = "";


        protected Block()
        {
            blockState = new NotActivatedBlockState(this);
            location = new Vector2(0, 0);
        }

        public int BumpTimer { get => bumpTimer; set => bumpTimer = value; }
        public int Timeout { get => timeout; set => timeout = value; }
        public IBlockState BumpState { get => bumpState; set => bumpState = value; }
        public IBlockState BlockState { get => blockState; set => blockState = value; }
        public virtual Vector2 Location { get => location; set => location = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }
        protected string Id { get => id; set => id = value; }
        protected ISprite BlockSprite { get => blockSprite; set => blockSprite = value; }

        public virtual void Activate()
        {
            blockState.Activate();
        }

        public virtual void Bump() {
        }

        public virtual void Despawn()
        {
            PlayerLevel.Instance.BlockArray.Remove(this);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 spriteLocation, Color color)
        {
            if (BumpState is BumpedBlockState)
            {
                blockSprite.Draw(spriteBatch, new Vector2(spriteLocation.X, spriteLocation.Y - 6), color);
            }
            else
            {
                blockSprite.Draw(spriteBatch, spriteLocation, color);
            }
        }

        public virtual void SpawnItem()
        {
            SoundFactory.Instance.PlaySoundEffect("SOUND_BUMP");
        }
        public virtual void Update()
        {
            blockSprite.Update();
            hitbox = blockSprite.GetHitboxFromSprite(location);
            if (bumpTimer == 0)
            {
                bumpTimer = 6;
                BumpState = null;
            }
            else if (bumpTimer < 6)
            {
                bumpTimer--;
            }

            if (timeout < 5)
            {
                timeout--;
            }

            if (timeout < 3)
            {
                BlockState = new ActivatedBlockState(this);
            }

            if (timeout < 0)
            {
                PlayerLevel.Instance.DespawnList.Add(this);
            }
        }

        public void UpdateSprite()
        {
            blockSprite = TerrainSpriteFactory.Instance.CreateSprite(blockState, id);
        }
    }
}
