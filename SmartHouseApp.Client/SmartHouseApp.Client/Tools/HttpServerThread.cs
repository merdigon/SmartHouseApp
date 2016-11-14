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
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Prefix = ip.ToString();
                    break;
                }
            }

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
                    var positionForPoint = ResizeUserLocalizationDependingOnPictureSize(MainForm, model.X, model.Y);
                    MainForm.Points.Add(new Model.PointOnMap
                    {
                        X = positionForPoint.Item1,
                        Y = positionForPoint.Item2,
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

        public static Tuple<int, int> ResizeUserLocalizationDependingOnPictureSize(Form1 mainForm, double x, double y)
        {
            int xIS = mainForm.PictureSize.Width;
            int yIS = mainForm.PictureSize.Height;
            int xPB = mainForm.pictureBox1.Size.Width;
            int yPB = mainForm.pictureBox1.Size.Height;
            int marginSize;

            if(xIS/yIS > xPB / yPB)
            {
                int xPOPR = xPB;
                int yPOPR = (xPOPR * yIS) / xIS;
                marginSize = (yPB - yPOPR) / 2;
                int xREAL = (int)((x / mainForm.MapSize.Width) * xPOPR);
                int yREAL = (int)((y / mainForm.MapSize.Height) * yPOPR);
                return new Tuple<int, int>(xREAL, yREAL + marginSize);
            }
            else
            {
                int yPOPR = yPB;
                int xPOPR = (yPOPR * xIS) / yIS;
                marginSize = (xPB - xPOPR) / 2;
                int xREAL = (int)((x / mainForm.MapSize.Width) * xPOPR);
                int yREAL = (int)((y / mainForm.MapSize.Height) * yPOPR);
                return new Tuple<int, int>(xREAL + marginSize, yREAL);
            }
        }
    }
}
