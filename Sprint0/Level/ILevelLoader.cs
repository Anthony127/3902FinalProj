using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprint0.Level
{
    interface ILevelLoader
    {
        ILevel LoadLevelFromFile(String filename);
        ILevel LoadLevel(XmlReader fileStream);



    }
}
