using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IItem
    {
        Vector2 GetLocation();
        Rectangle GetHitbox();
        void SetLocation(Vector2 location);
        void SetHitbox(Rectangle hitbox);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
