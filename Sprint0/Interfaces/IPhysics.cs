using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IPhysics
    {
        Vector2 Velocity { get; set; }
        Vector2 Friction { get; set; }
        Vector2 Location { get; set; }
    }
}
