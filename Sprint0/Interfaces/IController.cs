using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperPixelBrosGame.Commands;

namespace SuperPixelBrosGame
{
    interface IController
    {
        void Update();
        void RegisterCommands();
    }
}
