using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame.MasterClasses
{
    class OneUpMushroom : IItem, ICollidable, IPhysics
    {
        private ISprite itemSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "ONEU";
        private Vector2 velocity;
        private Vector2 friction;
        private Vector2 gravity = new Vector2(0, (float).3);

        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public Vector2 Friction
        {
            get
            {
                return friction;
            }
            set
            {
                friction = value;
            }
        }

        public Vector2 Location { get => location; set => location = value; }

        public OneUpMushroom()
        {
            velocity = new Vector2((float)1.5, 0);
            location = new Vector2(0, 0);
            UpdateSprite();
            hitbox = itemSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Update()
        {
            velocity.Y += gravity.Y;
            location.X += velocity.X;
            location.Y += velocity.Y;
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

        public void Despawn()
        {
            PlayerLevel.Instance.itemArray.Remove(this);
        }

        public void Bounce()
        {
            throw new System.NotImplementedException();
        }
    }
}