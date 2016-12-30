//using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartHouseAppTester
{
    public static class RestClient
    {
        public static T Get<T>(string path)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://" + Configuration.Conf.ServerIp + "/api/" + path);
            
            request.Method = "GET";
            request.ContentType = "text/xml";            

            var s = request.GetResponse();
            return (T)new XmlSerializer(typeof(T)).Deserialize(s.GetResponseStream());
        }

        public static T Post<T>(string path, object model)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://" + Configuration.Conf.ServerIp + "/api/" + path);

            request.Method = "POST";
            request.ContentType = "text/xml";

            if (model != null)
            {
                XmlSerializer serializer = new XmlSerializer(model.GetType());
                serializer.Serialize(request.GetRequestStream(), model);
            }
            else
                request.ContentLength = 0;

            var s = request.GetResponse();
            return (T)new XmlSerializer(typeof(T)).Deserialize(s.GetResponseStream());
        }
    }
}
