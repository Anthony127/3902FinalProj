using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Sprint0
{
    public class EnemySpriteFactory : ISpriteFactory
    {

        private Texture2D enemySpriteSheet;

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
            enemySpriteSheet = contentManager.Load<Texture2D>("Sprites/enemiesSMW");
        }
        
        public ISprite CreateGoombaSprite()
		{
			return new GoombaSprite(enemySpriteSheet);
		}

        public ISprite CreateKoopaSprite()
		{
		    return new KoopaSprite(enemySpriteSheet);
		}

    }
}
