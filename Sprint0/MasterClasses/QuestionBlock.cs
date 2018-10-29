using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.MasterClasses;
using SuperPixelBrosGame.States.Blocks;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class QuestionBlock : IBlock, ICollidable
    {
        private IBlockState blockState;
        private ISprite blockSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "QB";
        private int bumpTimer = 6;

        int IBlock.BumpTimer { get => bumpTimer; set => bumpTimer = value; }
        public IBlockState BumpState { get; set; }

        public QuestionBlock()
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
            if (Mario.Instance.GetConditionState().ConditionCode.Equals("SMLL"))
            {
                IItem powerup = new SuperMushroom();
                powerup.SetLocation(new Vector2(location.X, location.Y - 32));
                Level.PlayerLevel.Instance.itemArray.Add(powerup);
            }
            else
            {
                IItem powerup = new FireFlower();
                powerup.SetLocation(new Vector2(location.X, location.Y - 32));
                Level.PlayerLevel.Instance.itemArray.Add(powerup);
            }
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