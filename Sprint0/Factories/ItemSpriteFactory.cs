using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprint0.Interfaces;

namespace Sprint0
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

        public ISprite CreateCoinSprite()
        {
            return new CoinSprite(itemSpriteSheet);
        }
        public ISprite CreateFireFlowerSprite()
        {
            return new FireFlowerSprite(itemSpriteSheet);
        }
        public ISprite CreateOneUpMushroomSprite()
        {
            return new OneUpMushroomSprite(itemSpriteSheet);
        }
        public ISprite CreateStarSprite()
        {
            return new StarSprite(itemSpriteSheet);
        }
        public ISprite CreateSuperMushroomSprite()
        {
            return new SuperMushroomSprite(itemSpriteSheet);
        }

        public ISprite CreateSprite(IMovementState movement, IConditionState condition)
        {
            throw new NotImplementedException();
        }
    }
}
