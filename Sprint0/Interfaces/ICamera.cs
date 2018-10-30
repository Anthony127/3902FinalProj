using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface ICamera
    {
        void CameraUpdate();

        Rectangle Bounds { get; set; }
        Matrix Transform { get; set; }
    }
}
