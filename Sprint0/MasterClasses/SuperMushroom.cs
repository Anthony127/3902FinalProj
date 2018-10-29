using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class SuperMushroom : Item, IItem, ICollidable, IPhysics
    {

        public SuperMushroom()
        {
            Id = "SUPE";
            Velocity = new Vector2((float)1.5, 0);
            UpdateSprite();
           Hitbox = ItemSprite.GetHitboxFromSprite(Location);
        }
    }
}
