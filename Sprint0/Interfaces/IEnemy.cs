using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface IEnemy
    {
        IMovementState MovementState { get; set; }
        IConditionState ConditionState { get; set; }
        Vector2 Location { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void RunLeft();
        void RunRight();
        void TakeDamage();
        void UpdateSprite();

        void PopOff();

    }
}
