using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.MasterClasses
{
    class OneUpMushroom : IItem, ICollidable
    {
        private ISprite itemSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "ONEU";

        public OneUpMushroom()
        {
            location = new Vector2(0, 0);
            UpdateSprite();
            hitbox = itemSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Update()
        {
            itemSprite.Update();
            hitbox = itemSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            itemSprite.Draw(spriteBatch, location, color);
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