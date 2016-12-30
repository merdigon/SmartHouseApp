using SmartHouseApp.Client.Model;
using SmartHouseApp.Client.Tools;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

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
        public Tuple<double, double> MapSize { get; set; }
        public Form1()
        {
            InitializeComponent();
            try
            {
                HttpServer = new HttpServerThread(this);
                ServerThread = new Thread(new ThreadStart(HttpServer.Threading));
                ServerThread.Start();
                groupBox2.Enabled = rbRealTime.Enabled = rbTimeStamp.Enabled = true;
                pictureBox1.ImageLocation = Configuration.Conf.PictureLocation;
                PictureSize = Image.FromFile(Configuration.Conf.PictureLocation).Size;
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Controls.Add(pictureBox2);
                pictureBox2.BackColor = Color.Transparent;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                Points = new List<PointOnMap>();
                RefreshRenderDevices();

                PointPainter = new PointPainter(this);
                PointPainterThread = new Thread(new ThreadStart(PointPainter.DrawPoints));
                PointPainterThread.Start();
            }
            catch(Exception ex)
            {
                InfoForm.ShowError(ex.Message);
            }
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
            if (DeviceList != null)
                DeviceList.Clear();

            DeviceList = RestClient.Get<List<DeviceRenderViewModel>>("Client/GetRenderDevices");
        }

        public void ChangeServerSubscription(bool ifRealTime)
        {
            if (ifRealTime)
            {
                Points.Clear();
                using (var client = new HttpClient())
                {
                    var response = RestClient.Post<bool>("Client/StartRealTime", null);
                    HttpServer.StartListening();
                }
            }
            else
            {
                Points.Clear();
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
            if(PointPainterThread != null)
                PointPainterThread.Abort();

            if(ServerThread != null)
                ServerThread.Abort();
        }

        private void btnRefreshDevices_Click(object sender, EventArgs e)
        {
            RefreshRenderDevices();
        }
    }
}
