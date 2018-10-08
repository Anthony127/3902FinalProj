using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Commands;

namespace Sprint0
{
    interface IController
    {
        void Update();
        void RegisterCommands();
    }
}
