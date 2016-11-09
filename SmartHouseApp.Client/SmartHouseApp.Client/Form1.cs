using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client
{
    public partial class Form1 : Form
    {
        HttpServerThread HttpServer { get; set; }
        Thread ServerThread { get; set; }
        public bool Registered { get; set; }
        public Form1()
        {
            InitializeComponent();

            groupBox2.Enabled = false;
            rbRealTime.Enabled = false;
            rbTimeStamp.Enabled = false;
            Registered = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool ifLogInwasSuccessful = false;

            using (var client = new HttpClient())
            {
                var response = client.PostAsync("http://" + tbIp.Text + "/LogIn/", null);
                var responseString = response.Result.Content.ReadAsStringAsync();

                bool.TryParse(responseString.Result, out ifLogInwasSuccessful);
            }

            if (ifLogInwasSuccessful)
            {
                HttpServer = new HttpServerThread(tbIp.Text);
                ServerThread = new Thread(new ThreadStart(HttpServer.Threading));
                ServerThread.Start();
                btnRegister.Enabled = tbIp.Enabled = false;
                groupBox2.Enabled = rbRealTime.Enabled = rbTimeStamp.Enabled = true;
            }
        }

        private void rbRealTime_CheckedChanged(object sender, EventArgs e)
        {
            ChangeServerSubscription(rbRealTime.Checked);
        }

        public void ChangeServerSubscription(bool ifRealTime)
        {
            if (ifRealTime)
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(tbIp.Text + "/RequireSubscription/", null);
                    var responseString = response.Result.Content.ReadAsStringAsync();
                    HttpServer.StartListening();
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(tbIp.Text + "/AbortSubscription/", null);
                    var responseString = response.Result.Content.ReadAsStringAsync();
                    HttpServer.StopListening();
                }
            }
        }

        private void rbTimeStamp_CheckedChanged(object sender, EventArgs e)
        {
            ChangeServerSubscription(rbRealTime.Checked);
        }
    }
}
