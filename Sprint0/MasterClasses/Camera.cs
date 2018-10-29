using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;

namespace SuperPixelBrosGame
{
    class Camera : ICamera
    {
        Viewport view;
        Vector2 centerPoint;
        public Matrix transform;


        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void CameraUpdate()
        {
            centerPoint = new Vector2(Mario.Instance.Location.X - 392, 0);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centerPoint.X, -centerPoint.Y, 0));
        }
    }
}
