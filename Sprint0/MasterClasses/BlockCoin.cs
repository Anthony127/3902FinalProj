using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.HUDComponents;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.MasterClasses
{
    class BlockCoin : Item, IItem, ICollidable, IPhysics
    {
        int itemTimer;

        public BlockCoin()
        {
            Id = "COIN";
            itemTimer = 50;
            UpdateSprite();
            Hitbox = new Rectangle((int)Location.X, (int)Location.Y, 0, 0);
        }

        public override void Update()
        {
            ItemSprite.Update();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);

            itemTimer--;
            if (itemTimer == 0) {
                PlayerLevel.Instance.RemoveArray.Add(this);
                ScoreKeeper.Instance.IncrementCoins();
            }
        }

    }
}
