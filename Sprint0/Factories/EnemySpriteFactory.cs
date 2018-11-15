using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperPixelBrosGame.Interfaces;
using System.Collections.Generic;
using System;
using System.Reflection;
using SuperPixelBrosGame.States.Enemies.Movement;
using SuperPixelBrosGame.States.Enemies;
using SuperPixelBrosGame.States.Enemies.Condition;

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

            enemyDictionary.Add(typeof(Koopa).ToString() + typeof(EnemyLeftRunState).ToString() + typeof(EnemyNormalState).ToString(), typeof(KoopaLeftSprite));
            enemyDictionary.Add(typeof(Koopa).ToString() + typeof(EnemyRightRunState).ToString() + typeof(EnemyNormalState).ToString(), typeof(KoopaRightSprite));
            enemyDictionary.Add(typeof(Koopa).ToString() + typeof(EnemyLeftRunState).ToString() + typeof(EnemyDefeatedState).ToString(), typeof(KoopaShellSprite));
            enemyDictionary.Add(typeof(Koopa).ToString() + typeof(EnemyRightRunState).ToString() + typeof(EnemyDefeatedState).ToString(), typeof(KoopaShellSprite));
            enemyDictionary.Add(typeof(Koopa).ToString() + typeof(EnemyPoppedMoveState).ToString() + typeof(EnemyPoppedState).ToString(), typeof(KoopaPoppedSprite));

            enemyDictionary.Add(typeof(Goomba).ToString() + typeof(EnemyPoppedMoveState).ToString() + typeof(EnemyPoppedState).ToString(), typeof(GoombaPoppedSprite));
            enemyDictionary.Add(typeof(Goomba).ToString() + typeof(EnemyLeftRunState).ToString() + typeof(EnemyNormalState).ToString(), typeof(GoombaLeftSprite));
            enemyDictionary.Add(typeof(Goomba).ToString() + typeof(EnemyRightRunState).ToString() + typeof(EnemyNormalState).ToString(), typeof(GoombaRightSprite));
            enemyDictionary.Add(typeof(Goomba).ToString() + typeof(EnemyLeftRunState).ToString() + typeof(EnemyDefeatedState).ToString(), typeof(GoombaLeftStompedSprite));
            enemyDictionary.Add(typeof(Goomba).ToString() + typeof(EnemyRightRunState).ToString() + typeof(EnemyDefeatedState).ToString(), typeof(GoombaRightStompedSprite));

        }
        
        public ISprite CreateSprite(IMovementState movement, IConditionState condition, IEnemy enemyType)
        {
            string code = "";
            ISprite sprite;
            Type spriteType;
            if (movement != null && condition != null)
            {
                code = enemyType.GetType().ToString() + movement.GetType().ToString() + condition.GetType().ToString();
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
