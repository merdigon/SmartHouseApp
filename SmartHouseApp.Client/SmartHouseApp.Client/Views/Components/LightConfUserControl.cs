using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHouseApp.Client.Model.DeviceRender;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using SmartHouseApp.Client.Tools;

namespace SmartHouseApp.Client.Views.Components
{
    public partial class LightConfUserControl : UserControl, IDeviceConfControl
    {
        LightDeviceRender model = null;

        public LightConfUserControl(LightDeviceRender model)
        {
            InitializeComponent();

            this.model = model;
            tbIp.Text = model.Ip;
            tbPort.Text = model.Port;
            tbMaxPerc.Text = model.MaxPercentagePower.ToString();
            tbMinPerc.Text = model.MinPercentagePower.ToString();
            tbVisibleName.Text = model.VisibleName;
            tbX.Text = model.X.ToString();
            tbY.Text = model.Y.ToString();
            tbZ.Text = model.Z.ToString();
        }

        public bool Save()
        {
            int max = int.Parse(tbMaxPerc.Text);
            int min = int.Parse(tbMinPerc.Text);
            double x = double.Parse(tbX.Text);
            double y = double.Parse(tbY.Text);
            double z = double.Parse(tbZ.Text);

            var model = new LightDeviceViewModel
            {
                DeviceId = this.model.DeviceId,                
                Ip = tbIp.Text,
                MaxPercentagePower = max,
                MinPercentagePower = min,
                Port = tbPort.Text,
                VisibleName = tbVisibleName.Text,
                X = x,
                Y = y,
                Z = z
            };

            return RestClient.Post<bool>("Conf/SaveLightDevice", model);
        }
    }
}
