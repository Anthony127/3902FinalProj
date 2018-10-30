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
            Id = "COIN";
            UpdateSprite();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }

        public override void Update()
        {
            ItemSprite.Update();
            Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }

    }
}
