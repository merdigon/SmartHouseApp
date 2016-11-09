using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHouseApp.Client
{
    public class HttpServerThread
    {
        HttpListener listener;
        private string Prefix { get; set; }
        private bool Listening { get; set; }

        public HttpServerThread(string prefix)
        {
            Prefix = prefix;
            listener = new HttpListener();
            listener.Prefixes.Add("http://" + Prefix + ":50675/");
        }

        public void Threading()
        {
            while(true)
            {
                if (Listening)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    using (var bodyStream = new StreamReader(request.InputStream))
                    {
                        var text = bodyStream.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public void StopListening()
        {
            Listening = false;
            listener.Stop();
        }

        public void StartListening()
        {
            Listening = true;
            listener.Start();
        }
    }
}
