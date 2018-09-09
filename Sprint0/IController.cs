﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    interface IController
    {
        void Update();
        void RegisterCommand(string key, ICommand command);
    }
}
