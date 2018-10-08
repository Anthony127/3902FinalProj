﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ICollisionHandler
    {
        void HandleCollision(ICollision collision);
        void LoadCollisionResponses();
    }
}
