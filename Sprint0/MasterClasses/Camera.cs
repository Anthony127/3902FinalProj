using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuperPixelBrosGame
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void CameraUpdate()
        {
            center = new Vector2(Mario.Instance.GetLocation().X - 392, 0);
            Debug.WriteLine("MARIO LOCATION: " + Mario.Instance.GetLocation().X + ", " + Mario.Instance.GetLocation().Y);
            transform = Matrix.CreateScale(new Vector3((float)1, (float)1, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
