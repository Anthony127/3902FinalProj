﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.MasterClasses
{
    class OneUpMushroom : IItem
    {
        private ISprite itemSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "ONEU";

        public OneUpMushroom()
        {
            location = new Vector2(0, 0);
            hitbox = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            UpdateSprite();
        }

        public void Update()
        {
            itemSprite.Update();
            hitbox = new Rectangle((int)location.X, (int)location.Y, hitbox.Width, hitbox.Height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            itemSprite.Draw(spriteBatch, location);
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        public void SetHitbox(Rectangle hitbox)
        {
            this.hitbox = hitbox;
        }

        private void UpdateSprite()
        {
            itemSprite = ItemSpriteFactory.Instance.CreateSprite(ID);
        }
    }
}