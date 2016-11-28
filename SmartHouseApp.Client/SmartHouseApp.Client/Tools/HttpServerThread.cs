using SmartHouseApp.Client.Views;
using SmartHouseApp.Share.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmartHouseApp.Client
{
    public class HttpServerThread
    {
        HttpListener listener;
        private string Prefix { get; set; }
        private bool Listening { get; set; }
        private Form1 MainForm { get; set; }

        public HttpServerThread(Form1 mainForm)
        {
            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        Prefix = ip.ToString();
            //        break;
            //    }
            //}

            Prefix = "192.168.1.5";

            listener = new HttpListener();
            listener.Prefixes.Add("http://" + Prefix + ":52078/");
            MainForm = mainForm;
        }

        public void Threading()
        {
            listener.Start();
            while(true)
            {
                if (Listening)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    XmlSerializer serializer = new XmlSerializer(typeof(UserPositionModel));
                    UserPositionModel model = (UserPositionModel)serializer.Deserialize(request.InputStream);
                    MainForm.Points.Add(new Model.PointOnMap
                    {
                        X = model.X,
                        Y = model.Y,
                        ExpirationDate = DateTime.Now.AddSeconds(4)
                    });
                    var buffer = Encoding.UTF8.GetBytes("true");
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                }
                Thread.Sleep(1000);
            }
        }

        public void StopListening()
        {
            Listening = false;
        }

        public void StartListening()
        {
            Listening = true;
        }
    }
}
