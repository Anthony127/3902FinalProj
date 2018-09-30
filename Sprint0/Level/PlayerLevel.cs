using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Level
{
    class PlayerLevel
    {
        private static PlayerLevel instance = new PlayerLevel();

        public static PlayerLevel Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
