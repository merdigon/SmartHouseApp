using SmartHouseApp.Common.Repository;
using SmartHouseApp.Tester.ServerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SmartHouseApp.Tester
{
    public partial class Form1 : Form
    {
        private static int RESIZER = 5;
        public Form1()
        {
            InitializeComponent();

            Size = new Size((Configuration.Conf.MapSizeX * RESIZER) + 215, (Configuration.Conf.MapSizeY * RESIZER) + 39);

            //InitServers();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;

            Tuple<int, int> userPoss = new Tuple<int, int>((x / RESIZER), (y / RESIZER));

            DeviceNotificationModel model = new DeviceNotificationModel();
            model.SourceName = "sdf234sdgf34";
            List<SignalStrengthDataModel> signals = new List<SignalStrengthDataModel>();

            foreach(var router in Configuration.Conf.RoutersInfo)
            {
                var distance = Math.Sqrt(Math.Pow(userPoss.Item1 - router.Location.X, 2.0) + Math.Pow(userPoss.Item2 - router.Location.Y, 2.0));
                var power = router.TrasmitterPower + router.AntennaGain + 2 - router.FadeMargin - 20 * Math.Log10(distance) + 27.55 - 67.55;
                var routerModel = new SignalStrengthDataModel
                {
                    DeviceName = router.SSID,
                    Type = SignalType.WIFI,
                    SignalStrength = (int)power
                };
                signals.Add(routerModel);
            }
            model.SignalData = signals.ToArray();

            var request = (HttpWebRequest)WebRequest.Create("http://192.168.1.105:52079/api/DataCollector/ReportDevices");

            XmlSerializer serializer = new XmlSerializer(typeof(DeviceNotificationModel));

            request.Method = "POST";
            request.ContentType = "text/xml";

            serializer.Serialize(request.GetRequestStream(), model);
            //request.ContentLength = request.GetRequestStream().Length;

            request.GetResponse();
        }

        //List<Thread> DeviceThreads { get; set; }
        //public void InitServers()
        //{
        //    List<LightDeviceDomain> lightDevices = new List<LightDeviceDomain>();

        //    using (var repo = new Repository<LightDeviceDomain>())
        //    {
        //        var allFromRepo = repo.All();
        //        lightDevices.AddRange(allFromRepo.Where(p => p.Interface.VisibleName.Equals("Logger")).ToList());
        //    }

        //    DeviceThreads = new List<Thread>();
        //    foreach(var device in lightDevices)
        //    {
        //        var threadHelper = new LightDeviceThread
        //        {
        //            Ip = device.Ip,
        //            Port = device.Port,
        //            MainForm = this
        //        };
        //        var thread = new Thread(new ThreadStart(threadHelper.Listen));
        //        DeviceThreads.Add(thread);
        //        thread.Start();
        //    }
        //}

        public void AddNewLog(string log)
        {
            tbLogText.Text = tbLogText.Text + Environment.NewLine + log;
            tbLogText.Refresh();
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if(DeviceThreads!=null && DeviceThreads.Count > 0)
        //    {
        //        foreach(var thread in DeviceThreads)
        //            thread.Abort();
        //    }
        //}
    }
}
