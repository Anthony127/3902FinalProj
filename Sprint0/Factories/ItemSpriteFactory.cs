using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperPixelBrosGame.Interfaces;
using System.Reflection;
using SuperPixelBrosGame.MasterClasses;

namespace SuperPixelBrosGame
{
    public class ItemSpriteFactory : ISpriteFactory
    {
        private Texture2D itemSpriteSheet;
        private IDictionary<string, Type> itemDictionary = new Dictionary<string, Type>();

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadTextures(ContentManager contentManager)
        {
            itemSpriteSheet = contentManager.Load<Texture2D>("Sprites/itemsSMW");

            itemDictionary.Add(typeof(Coin).ToString(), typeof(CoinSprite));
            itemDictionary.Add(typeof(BlockCoin).ToString(), typeof(CoinSprite));
            itemDictionary.Add(typeof(FireFlower).ToString(), typeof(FireFlowerSprite));
            itemDictionary.Add(typeof(SuperMushroom).ToString(), typeof(SuperMushroomSprite));
            itemDictionary.Add(typeof(OneUpMushroom).ToString(), typeof(OneUpMushroomSprite));
            itemDictionary.Add(typeof(Star).ToString(), typeof(StarSprite));
            itemDictionary.Add(typeof(FireBall).ToString(), typeof(FireBallSprite));
            itemDictionary.Add(typeof(FireBallExploded).ToString(), typeof(FireBallExplodedSprite));
        }

        public ISprite CreateSprite(string id)
        {
            ISprite sprite;
            Type spriteType;
            itemDictionary.TryGetValue(id, out spriteType);
            if (spriteType != null)
            {

                ConstructorInfo[] constr = new ConstructorInfo[1];
                constr = spriteType.GetConstructors();
                sprite = (ISprite)constr[0].Invoke(new object[] { itemSpriteSheet });
            }
            else
            {
                sprite = new CoinSprite(itemSpriteSheet);
            }
            return sprite;
        }
    }
}
