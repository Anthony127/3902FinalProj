using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace sprint0
{
    public class EnemySpriteFactory : ISpriteFactory
    {

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public EnemySpriteFactory()
        {

        }

        public void LoadTextures(ContentManager contentManager)
        {
            //No-op until textures are chosen.
        }

        
    }
}
