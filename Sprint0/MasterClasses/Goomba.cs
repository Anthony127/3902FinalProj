﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.States.Enemies.Condition;
using SuperPixelBrosGame.States.Enemies.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class Goomba : IEnemy, ICollidable
    {
        private IMovementState movementState;
        private IConditionState conditionState;
        private ISprite goombaSprite;
        private Rectangle hitbox;
        private Vector2 location;
        private readonly string ID = "GM";

        public Goomba()
        {
            movementState = new EnemyLeftRunState(this);
            conditionState = new EnemyNormalState(this);
            location = new Vector2(0, 0);
            UpdateSprite();
            hitbox = goombaSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Update()
        {
            goombaSprite.Update();
            hitbox = goombaSprite.GetHitboxFromSprite(GetLocation());
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            goombaSprite.Draw(spriteBatch, location, color);
        }

        public IConditionState GetConditionState()
        {
            return conditionState;
        }

        public IMovementState GetMovementState()
        {
            return movementState;
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

        public void SetConditionState(IConditionState condition)
        {
            conditionState = condition;
        }

        public void SetMovementState(IMovementState movement)
        {
            movementState = movement;
        }

        public void SetHitbox(Rectangle hitbox)
        {
            this.hitbox = hitbox;
        }

        public void RunLeft()
        {
            movementState.RunLeft();
            UpdateSprite();
        }

        public void RunRight()
        {
            movementState.RunRight();
            UpdateSprite();
        }

        public void TakeDamage()
        {
            conditionState.TakeDamage();
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            goombaSprite = EnemySpriteFactory.Instance.CreateSprite(movementState, conditionState, ID);
        }
    }
}
