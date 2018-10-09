using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Interfaces
{
    public interface ICollisionDetector
    {

        ICollision ScanForCollisions(IMario mario, IList<IEnemy> entities);
        ICollision ScanForCollisions(IMario mario, IList<IItem> entities);
        ICollision ScanForCollisions(IMario mario, IList<IBlock> entities);
    }
}
