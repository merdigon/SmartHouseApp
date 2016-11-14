using SmartHouseApp.Client.Tools;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SmartHouseApp.Client
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();

            tbLogin.Text = Configuration.Conf.Login;
            tbPassword.Text = Configuration.Conf.Password;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var model = new LogInModel
                {
                    Login = tbLogin.Text,
                    Password = tbPassword.Text
                };

                LogInViewModel responseModel = RestClient.Post<LogInViewModel>("Client/LogIn", model);

                var mapSize = new Size(responseModel.MapSizeX, responseModel.MapSizeY);

                if(responseModel.Result)
                {
                    Form1 form = new Form1();
                    form.MapSize = mapSize;
                    Hide();
                    form.Closed += (s, args) => Close();
                    form.Show();
                }
            }
        }
    }
}
