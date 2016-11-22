using SmartHouseApp.Client.Model;
using SmartHouseApp.Client.Tools;
using SmartHouseApp.Client.Views;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SmartHouseApp.Client.Views
{
    public partial class Form1 : Form
    {
        public HttpServerThread HttpServer { get; set; }
        public PointPainter PointPainter { get; set; }
        public Thread PointPainterThread { get; set; }
        public Thread ServerThread { get; set; }
        public List<PointOnMap> Points { get; set; }
        public List<DeviceRenderViewModel> DeviceList { get; set; }
        public Size PictureSize { get; set; }
        public Size MapSize { get; set; }
        public Form1()
        {
            InitializeComponent();

            HttpServer = new HttpServerThread(this);
            ServerThread = new Thread(new ThreadStart(HttpServer.Threading));
            ServerThread.Start();
            groupBox2.Enabled = rbRealTime.Enabled = rbTimeStamp.Enabled = true;
            pictureBox1.ImageLocation = Configuration.Conf.PictureLocation;
            PictureSize = Image.FromFile(Configuration.Conf.PictureLocation).Size;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            Points = new List<PointOnMap>();
            RefreshRenderDevices();

            PointPainter = new PointPainter(this);
            PointPainterThread = new Thread(new ThreadStart(PointPainter.DrawPoints));
            PointPainterThread.Start();
        } 

        private void rbRealTime_CheckedChanged(object sender, EventArgs e)
        {
            ChangeServerSubscription(rbRealTime.Checked);

            if(rbRealTime.Checked)
            {
                lblEnd.Visible = false;
                lblStart.Visible = false;
                dtpEnd.Visible = false;
                dtpStart.Visible = false;
                btnDownload.Visible = false;
                btnClear.Visible = false;
            }
            else
            {
                lblEnd.Visible = true;
                lblStart.Visible = true;
                dtpEnd.Visible = true;
                dtpStart.Visible = true;
                btnDownload.Visible = true;
                btnClear.Visible = true;
                dtpStart.Value = DateTime.Now;
                dtpEnd.Value = DateTime.Now;
            }
        }

        public void RefreshRenderDevices()
        {
            DeviceList = RestClient.Get<List<DeviceRenderViewModel>>("Client/GetRenderDevices");
        }

        public void ChangeServerSubscription(bool ifRealTime)
        {
            if (ifRealTime)
            {
                using (var client = new HttpClient())
                {
                    var response = RestClient.Post<bool>("Client/StartRealTime", null);
                    HttpServer.StartListening();
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    var response = RestClient.Post<bool>("Client/StopRealTime", null);
                    HttpServer.StopListening();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var model = new DateSpawnModel
            {
                StartDate = dtpStart.Value,
                EndDate = dtpEnd.Value
            };

            List<UserPositionModel> responseModel = RestClient.Post<List<UserPositionModel>>("Client/GetUsersPositions", model);

            Points.Clear();
            foreach (var pos in responseModel)
            {
                Points.Add(new PointOnMap
                {
                    X = pos.X,
                    Y = pos.Y,
                    ExpirationDate = null
                });
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Points.Clear();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConfigurationForm form = new ConfigurationForm(this);
            form.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PointPainterThread.Abort();
            ServerThread.Abort();
        }
    }
}
