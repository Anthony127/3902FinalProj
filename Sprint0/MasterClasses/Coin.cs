using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.MasterClasses
{
    class Coin : Item, IItem, ICollidable, IPhysics
    {

        public Coin()
        {
            id = "COIN";
            UpdateSprite();
            hitbox = itemSprite.GetHitboxFromSprite(location);
        }

        public override void Update()
        {
            itemSprite.Update();
            hitbox = itemSprite.GetHitboxFromSprite(location);
        }
    }
}
