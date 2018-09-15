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
            //No -op for now, need to make a sprite class for mario. This is "Big Mario"
            return null; //Update Later
        }

        public ISprite CreateSmallMarioSprite()
        {
            return new SmallStandingMarioSprite(marioSpriteSheet);
        }

        public ISprite CreateFireMarioSprite()
        {
            //No-op for now, need to make a sprite class for fire mario.
            return null;//Update later
        }

        public ISprite CreateDeadMarioSprite()
        {
            //No-op for now, need to make a sprite class for dead mario.
            return null; //Update later
        }
    }
}
