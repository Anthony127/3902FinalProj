﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperPixelBrosGame.Commands
{
    class RightCommand : ICommand
    {
        public void Execute()
        {
            Mario.Instance.RunRight();
        }
    }
}
