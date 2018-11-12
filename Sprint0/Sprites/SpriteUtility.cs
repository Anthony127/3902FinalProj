using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Sprites
{
    class SpriteUtility
    {
        private static readonly SpriteUtility instance = new SpriteUtility();
        private int BLOCKUNIT;

        public int BLOCK_UNIT { get => BLOCKUNIT; private set => BLOCKUNIT = value; }

        public SpriteUtility(){
            BLOCK_UNIT = 32;
        }

        public static SpriteUtility Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
