using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class FireFlower : Item, IItem, ICollidable, IPhysics
    {

        public FireFlower()
        {
            id = "FIRE";
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