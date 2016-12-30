using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseAppTester
{
    public class LightDeviceThread
    {
        public string Ip { get; set; }
        public string Port { get; set; }
        public Form1 MainForm { get; set; }
        public HttpListener Listener { get; set; }
        
        public void Listen()
        {
            Listener = new HttpListener();
            Listener.Prefixes.Add(string.Format("http://{0}:{1}/", Ip, Port));
            Listener.Start();
            MainForm.Invoke((MethodInvoker)delegate ()
            {
                MainForm.AddNewLog(string.Format("Zarejestrowanie urządzenia o adresie: {0}:{1}", Ip, Port));
            });
            while (true)
            {
                HttpListenerContext context = Listener.GetContext();
                HttpListenerRequest request = context.Request;
                string msg = string.Empty;
                using (StreamReader str = new StreamReader(request.InputStream))
                {
                    msg = str.ReadToEnd();
                }

                MainForm.Invoke((MethodInvoker)delegate ()
                {
                    MainForm.AddNewLog(msg);
                });
            }
        }
    }
}
