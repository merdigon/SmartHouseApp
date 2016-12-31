using SmartHouseApp.Client.Tools;
using SmartHouseApp.Share.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client.Views
{
    public partial class AddEditDeviceGroup : Form
    {
        public DeviceGroupViewModel Model { get; set; }

        public AddEditDeviceGroup(DeviceGroupViewModel model)
        {
            InitializeComponent();
            this.Model = model;
            tbGroupName.Text = model.Name;

            ListViewItem item = new ListViewItem("Dostępne urządzenia", 0);
            
            //RestClient.Post<bool>("Conf/SaveLightDevice", model)
        }
    }
}
