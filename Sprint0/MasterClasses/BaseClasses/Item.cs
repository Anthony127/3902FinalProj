﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using SuperPixelBrosGame;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.MasterClasses.BaseClasses
{
    class Item : IItem, IPhysics, ICollidable
    {
        private Vector2 location;
        private Rectangle hitbox;
        private ISprite itemSprite;
        private string id = "";
        private Vector2 velocity;
        private Vector2 friction;
        private readonly Vector2 gravity = new Vector2(0, (float).3);

        public Vector2 Location { get => location; set => location = value; }
        public Vector2 Velocity { get => velocity; set => velocity = value; }
        public Vector2 Friction { get => friction; set => friction = value; }
        public Rectangle Hitbox { get => hitbox; set =>hitbox = value; }
        protected string Id { get => id; set => id = value; }
        protected ISprite ItemSprite { get => itemSprite; set => itemSprite = value; }


        protected Item()
        {
            friction = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
            location = new Vector2(0, 0);

        }
        public virtual void Bounce() { }

        public virtual void Despawn()
        {
            PlayerLevel.Instance.itemArray.Remove(this);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            itemSprite.Draw(spriteBatch, location, color);
        }

        public virtual void Update()
        {
            velocity.X += friction.X;
            velocity.Y += gravity.Y;
            location.X += velocity.X;
            location.Y += velocity.Y;
            itemSprite.Update();
           hitbox = itemSprite.GetHitboxFromSprite(location);
        }

        protected void UpdateSprite()
        {
            itemSprite = ItemSpriteFactory.Instance.CreateSprite(id);
        }
    }
}
