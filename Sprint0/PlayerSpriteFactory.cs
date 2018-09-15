using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        public ISprite CreateMarioSprite()
        {
            return new StandingMarioSprite(marioSpriteSheet);
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

        public ISprite CreateSmallMarioSprite()
        {
            return new SmallStandingMarioSprite(marioSpriteSheet);
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

        public ISprite CreateSmallMarioDeadSprite()
        {
            return new SmallDeadMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateFireMarioSprite()
        {
            return new FireStandingMarioSprite(marioSpriteSheet);
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
