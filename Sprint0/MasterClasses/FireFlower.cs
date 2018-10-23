using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Level;
using SuperPixelBrosGame.Interfaces;
using Sprint0.Interfaces;

namespace SuperPixelBrosGame.MasterClasses
{
    class FireFlower : IItem, ICollidable, IPhysics
    {
        private ISprite itemSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "FIRE";
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

        public FireFlower()
        {
            location = new Vector2(0, 0);
            UpdateSprite();
            hitbox = itemSprite.GetHitboxFromSprite(GetLocation());
        }

        public Vector2 Location { get => location; set => location = value; }
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

        public void Despawn()
        {
            PlayerLevel.Instance.itemArray.Remove(this);
        }

        public void Bounce()
        {
            velocity = new Vector2(velocity.X, -4);
        }
    }
}