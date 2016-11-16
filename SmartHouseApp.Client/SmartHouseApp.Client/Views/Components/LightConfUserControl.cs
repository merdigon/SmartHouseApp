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

namespace SmartHouseApp.Client.Views.Components
{
    public partial class LightConfUserControl : UserControl
    {
        public LightConfUserControl(LightDeviceRender model)
        {
            InitializeComponent();
        }
    }
}
