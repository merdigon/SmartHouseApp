using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartHouseApp.Client.Tools
{
    public class Configuration
    {
        private static Configuration _conf;

        public virtual string ServerIp { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string PictureLocation { get; set; }

        public static Configuration Conf
        {
            get
            {
                if (_conf == null)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                    using (StreamReader reader = new StreamReader("conf.xml"))
                    {
                        _conf = (Configuration)serializer.Deserialize(reader);
                    }
                }
                return _conf;
            }
        }
    }
}
