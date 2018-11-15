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
            itemTimer = 50;
        }

        public override void Update()
        {
            ItemSprite.Update();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);

            itemTimer--;
            if (itemTimer == 0) {
                PlayerLevel.Instance.DespawnList.Add(this);
                ScoreKeeper.Instance.IncrementCoins();
            }
        }

    }
}
