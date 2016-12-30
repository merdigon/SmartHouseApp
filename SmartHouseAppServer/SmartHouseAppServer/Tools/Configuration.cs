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
        
        public virtual double MapSizeX { get; set; }
        public virtual double MapSizeY { get; set; }
        public virtual string AdminLogin { get; set; }
        public virtual string AdminPassword { get; set; }

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
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.RelativeSearchPath + "/conf.xml"))
            {
                serializer.Serialize(writer, _conf);
                writer.Flush();
            }
            return true;
        }
    }
}
