using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface IGameState
    {
        void Update();
        void Draw(GraphicsDevice graphicsDevice);
    }
}
