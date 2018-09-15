using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sprint0
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
        }

        public ISprite CreateSmallMarioSprite()
        {
            return new SmallStandingMario(marioSpriteSheet);
        }

        public ISprite CreateFireMarioSprite()
        {
            //No-op for now, need to make a sprite class for fire mario.
        }

        public ISprite CreateDeadMarioSprite()
        {
            //No-op for now, need to make a sprite class for dead mario.
        }
    }
}
