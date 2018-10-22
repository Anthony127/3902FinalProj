using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface ICollisionIterator
    {

        void ProcessCollisions(IList<ICollidable> firstEntities, IList<ICollidable> secondEntities, ICollisionHandler collisionHandler);
    }
}
