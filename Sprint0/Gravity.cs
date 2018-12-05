using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame
{
    class Gravity
    {
        private Vector2 gravity;

        private Gravity()
        {
            gravity = new Vector2(0, (float).3);
        }

        public void EnableLowGravity()
        {
            gravity = new Vector2(0, (float).15);
        }
    }
}
