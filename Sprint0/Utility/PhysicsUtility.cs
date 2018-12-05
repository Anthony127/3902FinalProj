using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperPixelBrosGame
{
    public class PhysicsUtility
    {
        private static PhysicsUtility instance = new PhysicsUtility();
        private Vector2 gravity;

        public Vector2 Gravity { get => gravity; set => gravity = value; }
        public static PhysicsUtility Instance { get => instance; }

        private PhysicsUtility()
        {
            gravity = new Vector2(0, (float).3);
        }

        public void EnableLowGravity()
        {
            gravity = new Vector2(0, (float).15);
        }

        public void EnableNormalGravity()
        {
            gravity = new Vector2(0, (float).3);
        }
    }
}
