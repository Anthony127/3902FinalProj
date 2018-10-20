using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame
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

        private EnemySpriteFactory()
        {

        }
        
        public void LoadTextures(ContentManager contentManager)
        {
            enemySpriteSheet = contentManager.Load<Texture2D>("Sprites/enemiesSMW");
        }
        
        public ISprite CreateSprite(IMovementState movement, IConditionState condition, string id)
        {
            string movementCode = movement.MovementCode;
            string conditionCode = condition.ConditionCode;
            string code = id + movementCode + conditionCode;

            switch (code)
            {
                case "KPLRUNGOOD":
                    return new KoopaLeftSprite(enemySpriteSheet);
                case "KPRRUNGOOD":
                    
                case "KPLRUNDEAD":
                    return new KoopaShellSprite(enemySpriteSheet);
                case "KPRRUNDEAD":
                

                case "GMLRUNGOOD":
                    return new GoombaLeftSprite(enemySpriteSheet);
                case "GMRRUNGOOD":
                
                case "GMLRUNDEAD":
                    return new GoombaLeftStompedSprite(enemySpriteSheet);
                case "GMRRUNDEAD":
                
                default:
                    return new GoombaLeftSprite(enemySpriteSheet);
            }
        }
    }
}
