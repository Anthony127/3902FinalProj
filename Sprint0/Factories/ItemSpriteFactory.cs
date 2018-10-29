using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperPixelBrosGame.Interfaces;
using System.Reflection;

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

            itemDictionary.Add("COIN", typeof(CoinSprite));
            itemDictionary.Add("FIRE", typeof(FireFlowerSprite));
            itemDictionary.Add("SUPE", typeof(SuperMushroomSprite));
            itemDictionary.Add("ONEU", typeof(OneUpMushroomSprite));
            itemDictionary.Add("STAR", typeof(StarSprite));
            itemDictionary.Add("FIBA", typeof(FireBallSprite));
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
