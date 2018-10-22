using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame
{
    public class ItemSpriteFactory : ISpriteFactory
    {
        private Texture2D itemSpriteSheet;

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
        }

        public ISprite CreateSprite(string id)
        {
            switch (id)
            {
                case "COIN":
                    return new CoinSprite(itemSpriteSheet);
                case "FIRE":
                    return new FireFlowerSprite(itemSpriteSheet);
                case "SUPE":
                    return new SuperMushroomSprite(itemSpriteSheet);
                case "ONEU":
                    return new OneUpMushroomSprite(itemSpriteSheet);
                case "STAR":
                    return new StarSprite(itemSpriteSheet);
                case "FIBA":
                    return new FireBallSprite(itemSpriteSheet);
                default:
                    return new CoinSprite(itemSpriteSheet);
            }
        }
    }
}
