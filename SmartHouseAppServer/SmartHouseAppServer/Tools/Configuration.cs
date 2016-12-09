using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartHouseAppServer.Tools
{
    public class Configuration
    {
        private static Configuration _conf;
        
        public virtual int MapSizeX { get; set; }
        public virtual int MapSizeY { get; set; }

        public static Configuration Conf
        {
            get
            {
                if (_conf == null)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                    using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.RelativeSearchPath + "/conf.xml"))
                    {
                        _conf = (Configuration)serializer.Deserialize(reader);
                    }
                }
                return _conf;
            }
        }

        public static bool Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            using (StreamWriter writer = new StreamWriter("conf.xml"))
            {
                serializer.Serialize(writer, _conf);
                writer.Flush();
            }
            return true;
        }
    }
}
