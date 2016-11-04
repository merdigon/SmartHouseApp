using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://192.168.1.105:52079/api/DataCollector/ReportDevices";
            DeviceNotificationModel model = new DeviceNotificationModel
            {
                SignalData = new SignalStrengthDataModel[]
                {
                    new SignalStrengthDataModel {
                        DeviceName = "Ja",
                        SignalStrength = 60,
                        Type = SignalType.WIFI
                    }
                },
                SourceName = "Ziemia"
            };

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "POST";
            var json = JsonConvert.SerializeObject(model);
            var data = Encoding.ASCII.GetBytes(json);
            request.ContentLength = data.Length;

            using (Stream sw = request.GetRequestStream())
            {
                sw.Write(data, 0, data.Length);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string info = stream.ReadToEnd();
                }
            }
        }
    }
}
