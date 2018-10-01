using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ICollisionDetector
    {
        //REMOVEME for this sprint nothing can collide with anything except mario. Returning one ICollision may be weird if two pairs repeatedly collide for 
        //consecutive frames but not a worry this sprint. Later, might want this to be a queue of ICollisions.
        ICollision ScanForCollisions(IMario mario, List<IEnemy> entities);
        ICollision ScanForCollisions(IMario mario, List<IItem> entities);
        ICollision ScanForCollisions(IMario mario, List<IBlock> entities);
    }
}
