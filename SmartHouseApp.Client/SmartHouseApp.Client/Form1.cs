using SmartHouseApp.Client.Model;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SmartHouseApp.Client
{
    public partial class Form1 : Form
    {
        HttpServerThread HttpServer { get; set; }
        PointPainter PointPainter { get; set; }
        Thread PointPainterThread { get; set; }
        Thread ServerThread { get; set; }
        public bool Registered { get; set; }
        public List<PointOnMap> Points { get; set; }
        public Size PictureSize { get; set; }
        public Size MapSize { get; set; }
        public Form1()
        {
            InitializeComponent();

            groupBox2.Enabled = false;
            rbRealTime.Enabled = false;
            rbTimeStamp.Enabled = false;
            Registered = false;
            tbIp.Text = "192.168.1.105:52079";
            Points = new List<PointOnMap>();
            
            lblEnd.Visible = false;
            lblStart.Visible = false;
            dtpEnd.Visible = false;
            dtpStart.Visible = false;
            btnDownload.Visible = false;
            btnClear.Visible = false;

            PointPainter = new PointPainter(this);
            PointPainterThread = new Thread(new ThreadStart(PointPainter.DrawPoints));
            PointPainterThread.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool ifLogInwasSuccessful = false;

            using (var client = new HttpClient())
            {
                var model = new LogInModel
                {
                    Login = "admin",
                    Password = "admin"
                };

                var request = (HttpWebRequest)WebRequest.Create("http://" + tbIp.Text + "/api/Client/LogIn");

                XmlSerializer serializer = new XmlSerializer(typeof(LogInModel));
                request.Method = "POST";
                request.ContentType = "text/xml";

                serializer.Serialize(request.GetRequestStream(), model);

                var s = request.GetResponse();
                LogInViewModel responseModel = (LogInViewModel)new XmlSerializer(typeof(LogInViewModel)).Deserialize(s.GetResponseStream());
                MapSize = new Size(responseModel.MapSizeX, responseModel.MapSizeY);
                ifLogInwasSuccessful = responseModel.Result;
            }                

            if (ifLogInwasSuccessful)
            {
                HttpServer = new HttpServerThread(this);
                ServerThread = new Thread(new ThreadStart(HttpServer.Threading));
                ServerThread.Start();
                btnRegister.Enabled = tbIp.Enabled = false;
                groupBox2.Enabled = rbRealTime.Enabled = rbTimeStamp.Enabled = true;
                pictureBox1.ImageLocation = "plan.jpg";
                PictureSize = Image.FromFile("plan.jpg").Size;
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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

        public void ChangeServerSubscription(bool ifRealTime)
        {
            if (ifRealTime)
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync("http://" + tbIp.Text + "/api/Client/StartRealTime/", null);
                    var responseString = response.Result.Content.ReadAsStringAsync();
                    HttpServer.StartListening();
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync("http://" +  tbIp.Text + "/api/Client/StopRealTime/", null);
                    var responseString = response.Result.Content.ReadAsStringAsync();
                    HttpServer.StopListening();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://" + tbIp.Text + "/api/Client/GetUsersPositions");

            var model = new DateSpawnModel
            {
                StartDate = dtpStart.Value,
                EndDate = dtpEnd.Value
            };

            XmlSerializer serializer = new XmlSerializer(typeof(DateSpawnModel));
            request.Method = "POST";
            request.ContentType = "text/xml";

            serializer.Serialize(request.GetRequestStream(), model);

            var s = request.GetResponse();
            List<UserPositionModel> responseModel = (List<UserPositionModel>)new XmlSerializer(typeof(List<UserPositionModel>)).Deserialize(s.GetResponseStream());

            Points.Clear();
            foreach (var pos in responseModel)
            {
                var resizedPos = HttpServerThread.ResizeUserLocalizationDependingOnPictureSize(this, pos.X, pos.Y);
                Points.Add(new PointOnMap
                {
                    X = resizedPos.Item1,
                    Y = resizedPos.Item2,
                    ExpirationDate = null
                });
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Points.Clear();
        }
    }
}
