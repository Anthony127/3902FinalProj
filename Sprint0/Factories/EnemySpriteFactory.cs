using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;

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

        private EnemySpriteFactory()
        {

        }
        
        public void LoadTextures(ContentManager contentManager)
        {
            enemySpriteSheet = contentManager.Load<Texture2D>("Sprites/enemiesSMW");
        }
        
        public ISprite CreateSprite(IMovementState movement, IConditionState condition, string id)
        {
            string movementCode = movement.GetMovementCode();
            string conditionCode = condition.GetConditionCode();
            string code = id + movementCode + conditionCode;

            switch (code)
            {
                case "KPLRUNGOOD":
                    return new KoopaLeftSprite(enemySpriteSheet);
                case "KPRRUNGOOD":
                    //TODO
                case "KPLRUNDEAD":
                    return new KoopaShellSprite(enemySpriteSheet);
                case "KPRRUNDEAD":
                //TODO

                case "GMLRUNGOOD":
                    return new GoombaLeftSprite(enemySpriteSheet);
                case "GMRRUNGOOD":
                //TODO
                case "GMLRUNDEAD":
                //TODO
                case "GMRRUNDEAD":
                //TODO
                default:
                    return new GoombaLeftSprite(enemySpriteSheet);
            }
        }
    }
}
