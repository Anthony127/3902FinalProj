using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperPixelBrosGame.Interfaces
{
    public interface ICollidable
    {
        Vector2 Location { get; set; }
        Rectangle Hitbox { get; set; }
        void Despawn();
    }
}
