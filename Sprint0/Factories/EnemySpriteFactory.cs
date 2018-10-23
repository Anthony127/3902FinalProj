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
            string code = "";
            if (movement != null && condition != null)
            {
                string movementCode = movement.MovementCode;
                string conditionCode = condition.ConditionCode;
                code = id + movementCode + conditionCode;
            }

            switch (code)
            {
                case "KPLRUNGOOD":
                    return new KoopaLeftSprite(enemySpriteSheet);
                case "KPRRUNGOOD":
                    return new KoopaRightSprite(enemySpriteSheet);
                case "KPLRUNDEAD":
                case "KPRRUNDEAD":
                    return new KoopaShellSprite(enemySpriteSheet);
                case "KPPOPPOP":
                    return new KoopaPoppedSprite(enemySpriteSheet);
                

                case "GMLRUNGOOD":
                    return new GoombaLeftSprite(enemySpriteSheet);
                case "GMRRUNGOOD":
                    return new GoombaRightSprite(enemySpriteSheet);
                case "GMLRUNDEAD":
                    return new GoombaLeftStompedSprite(enemySpriteSheet);
                case "GMRRUNDEAD":
                    return new GoombaRightStompedSprite(enemySpriteSheet);
                case "GMPOPPOP":
                    return new GoombaPoppedSprite(enemySpriteSheet);
                default:
                    return new GoombaLeftSprite(enemySpriteSheet);
            }
        }
    }
}
