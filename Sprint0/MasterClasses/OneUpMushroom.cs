using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;
using Sprint0.MasterClasses.BaseClasses;

namespace SuperPixelBrosGame.MasterClasses
{
    class OneUpMushroom : Item, IItem, ICollidable, IPhysics
    {

        public OneUpMushroom()
        {
            id = "ONEU";
            velocity = new Vector2((float)1.5, 0);
            UpdateSprite();
           hitbox = itemSprite.GetHitboxFromSprite(location);
        }
    }
}