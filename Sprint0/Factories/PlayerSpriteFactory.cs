using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0.Interfaces;
using Sprint0.Sprites.MarioSprites.Mario;

namespace Sprint0
{
    public class PlayerSpriteFactory : ISpriteFactory
    {
        private Texture2D marioSpriteSheet;

        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public PlayerSpriteFactory()
        {

        }

        public void LoadTextures(ContentManager contentManager)
        {
            marioSpriteSheet = contentManager.Load<Texture2D>("marioSMW");
        }

        public IMarioSprite CreateSmallMarioSprite()
        {
            return new SmallMarioSprite(marioSpriteSheet);
        }
        public IMarioSprite CreateMarioSprite()
        {
            return new MarioSprite(marioSpriteSheet);
        }

        public ISprite CreateMarioCrouchingSprite()
        {
            return new CrouchingMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateMarioRunningSprite()
        {
            return new RunningMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateMarioJumpingSprite()
        {
            return new JumpingMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateSmallMarioCrouchingSprite()
        {
            return new SmallCrouchingMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateSmallMarioRunningSprite()
        {
            return new SmallRunningMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateSmallMarioJumpingSprite()
        {
            return new SmallJumpingMarioSprite(marioSpriteSheet);
        }

        public IMarioSprite CreateMarioDeadSprite()
        {
            return new DeadMarioSprite(marioSpriteSheet);
        }

        public IMarioSprite CreateFireMarioSprite()
        {
            return new FireMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateFireMarioCrouchingSprite()
        {
            return new FireCrouchingMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateFireMarioRunningSprite()
        {
            return new FireRunningMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateFireMarioJumpingSprite()
        {
            return new FireJumpingMarioSprite(marioSpriteSheet);
        }

    }
}
