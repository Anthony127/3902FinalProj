using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperPixelBrosGame.Interfaces;
using SuperPixelBrosGame.Level;

namespace SuperPixelBrosGame
{
    class Camera : ICamera
    {
        private Viewport view;
        private Vector2 centerPoint;
        private Matrix transform;

        public Rectangle Bounds { get => view.Bounds; set => view.Bounds = value; }
        public Matrix Transform { get => transform; set => transform = value; }

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void CameraUpdate()
        {
            
            if (Mario.Instance.Location.X > 8000)
            {
                centerPoint = new Vector2(8000, 0);
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centerPoint.X, -centerPoint.Y, 0));
                view.Bounds = new Rectangle(8400, 0, 900, 600);
            }
            else
            {
                centerPoint = new Vector2(Mario.Instance.Location.X - 400, 0);
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centerPoint.X, -centerPoint.Y, 0));
                view.Bounds = new Rectangle((int)Mario.Instance.Location.X, 0, 900, 600);
            }
        }
    }
}
