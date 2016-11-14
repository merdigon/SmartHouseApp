using SmartHouseApp.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartHouseApp.Common.KnowledgeDataStructures
{
    public class LoggedUser
    {
        public LoggedUser(string login, string ip)
        {
            Login = login;
            Ip = ip;
            NotifyRequested = false;
            IsOnline = true;
            IsAdmin = false;
        }

        public string Login { get; set; }
        public string Ip { get; set; }
        public bool NotifyRequested { get; set; } 
        public bool IsOnline { get; set; }
        public bool IsAdmin { get; set; }

        public async Task Notify(string userMac, double x, double y, double z)
        {
            var userPosition = new UserPositionModel
            {
                Mac = userMac,
                X = x,
                Y = y,
                Z = z
            };

            var request = (HttpWebRequest)WebRequest.Create("http://" + Ip + "/");

            XmlSerializer serializer = new XmlSerializer(typeof(UserPositionModel));

            request.Method = "POST";
            request.ContentType = "text/xml";

            serializer.Serialize(request.GetRequestStream(), userPosition);
            //request.ContentLength = request.GetRequestStream().Length;

            await request.GetResponseAsync();
        }
    }
}
