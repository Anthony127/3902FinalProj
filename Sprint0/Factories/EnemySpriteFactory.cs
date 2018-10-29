using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace SuperPixelBrosGame
{
    public class EnemySpriteFactory : ISpriteFactory
    {

        private Texture2D enemySpriteSheet;
        private IDictionary<string, Type> enemyDictionary = new Dictionary<string, Type>();

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

            enemyDictionary.Add("KPLRUNGOOD", typeof(KoopaLeftSprite));
            enemyDictionary.Add("KPRRUNGOOD", typeof(KoopaRightSprite));
            enemyDictionary.Add("KPLRUNDEAD", typeof(KoopaShellSprite));
            enemyDictionary.Add("KPRRUNDEAD", typeof(KoopaShellSprite));
            enemyDictionary.Add("KPPOPPOP", typeof(KoopaPoppedSprite));

            enemyDictionary.Add("GMLRUNGOOD", typeof(GoombaLeftSprite));
            enemyDictionary.Add("GMRRUNGOOD", typeof(GoombaRightSprite));
            enemyDictionary.Add("GMLRUNDEAD", typeof(GoombaLeftStompedSprite));
            enemyDictionary.Add("GMRRUNDEAD", typeof(GoombaRightStompedSprite));
            enemyDictionary.Add("GMPOPPOP", typeof(GoombaPoppedSprite));
        }
        
        public ISprite CreateSprite(IMovementState movement, IConditionState condition, string id)
        {
            string code = "";
            ISprite sprite;
            Type spriteType;
            if (movement != null && condition != null)
            {
                string movementCode = movement.MovementCode;
                string conditionCode = condition.ConditionCode;
                code = id + movementCode + conditionCode;

                
            }

            enemyDictionary.TryGetValue(code, out spriteType);
            if (spriteType != null)
            {

                ConstructorInfo[] constr = new ConstructorInfo[1];
                constr = spriteType.GetConstructors();
                sprite = (ISprite)constr[0].Invoke(new object[] { enemySpriteSheet });
            }
            else
            {
                sprite = new GoombaLeftSprite(enemySpriteSheet);
            }

            
            return sprite;
         
        }
    }
}
