using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface ICollisionHandler
    {
        void HandleCollision(ICollision collision);
        void LoadCollisionResponses();
    }
}
