using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprint0.Level
{
    class MarioLevelLoader : ILevelLoader
    {
        private static MarioLevelLoader instance = new MarioLevelLoader();

        public static MarioLevelLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public ILevel LoadLevelFromFile(string filename)
        {
            XmlReader fileReader = XmlReader.Create(filename);
            ILevel marioLevel = LoadLevel(fileReader);
            return marioLevel;
        }

        public ILevel LoadLevel(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "ObjectType":
                            Console.WriteLine("ObjectType : " + reader.ReadString());
                            break;
                        case "ObjectName":
                            Console.WriteLine("ObjectName : " + reader.ReadString());
                            break;
                        case "Location":
                            Console.WriteLine("Location : " + reader.ReadString());
                            break;
                    }
                }
                Console.WriteLine("");
            }
            return null;
        }
    }
}
