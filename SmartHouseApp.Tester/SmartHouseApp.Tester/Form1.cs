using SmartHouseApp.Share.ViewModel;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
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

namespace SmartHouseAppTester
{
    public partial class Form1 : Form
    {
        private double Resizer { get; set; }
        List<StaticRouterDataViewModel> routers;
        public Form1()
        {
            InitializeComponent();
            Resizer = (Configuration.Conf.MapSizeX >= Configuration.Conf.MapSizeY ? 800 / Configuration.Conf.MapSizeX : 500 / Configuration.Conf.MapSizeY);
            Size = new Size((int)(Configuration.Conf.MapSizeX * Resizer) + 370, (int)(Configuration.Conf.MapSizeY * Resizer) + 39);
            pictureBox1.ImageLocation = Configuration.Conf.NotRelativeMapPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            routers = RestClient.Get<List<StaticRouterDataViewModel>>("Conf/GetRoutersInfo");
            InitServers();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;

            Tuple<double, double> userPoss = new Tuple<double, double>((x / Resizer), (y / Resizer));

            DeviceNotificationModel model = new DeviceNotificationModel();
            model.SourceName = "sdf234sdgf34";
            List<SignalStrengthDataModel> signals = new List<SignalStrengthDataModel>();
            
            foreach (var router in routers)
            {
                var distance = Math.Sqrt(Math.Pow(userPoss.Item1 - router.LocationX, 2.0) + Math.Pow(userPoss.Item2 - router.LocationY, 2.0));
                var power = router.TrasmitterPower + router.AntennaGain + 2 - 22 - 20 * Math.Log10(distance) + 27.55 - 67.55;
                var routerModel = new SignalStrengthDataModel
                {
                    DeviceName = router.SSID,
                    Type = SignalType.WIFI,
                    SignalStrength = (int)Math.Round(power)
                };
                signals.Add(routerModel);
            }
            model.SignalData = signals.ToArray();

            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://" + Configuration.Conf.ServerIp + "/api/DataCollector/ReportDevices");

                XmlSerializer serializer = new XmlSerializer(typeof(DeviceNotificationModel));

                request.Method = "POST";
                request.ContentType = "text/xml";

                serializer.Serialize(request.GetRequestStream(), model);
                //request.ContentLength = request.GetRequestStream().Length;

                request.GetResponse();
            }
            catch (Exception ex) { }
        }

        List<Thread> DeviceThreads { get; set; }
        public void InitServers()
        {
            List<LightDeviceViewModel> lightDevices = RestClient.Post<List<LightDeviceViewModel>>("Conf/GetLightDevices", null);

            lightDevices = lightDevices.Where(p => p.Interface != null && p.Interface.VisibleName.Equals("Logger")).ToList();

            DeviceThreads = new List<Thread>();
            foreach (var device in lightDevices)
            {
                var threadHelper = new LightDeviceThread
                {
                    Ip = device.Ip,
                    Port = device.Port,
                    MainForm = this
                };
                var thread = new Thread(new ThreadStart(threadHelper.Listen));
                DeviceThreads.Add(thread);
                thread.Start();
            }
        }

        public void AddNewLog(string log)
        {
            tbLogText.Text = tbLogText.Text + Environment.NewLine + log;
            tbLogText.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DeviceThreads != null && DeviceThreads.Count > 0)
            {
                foreach (var thread in DeviceThreads)
                    thread.Abort();
            }
        }
    }
}
