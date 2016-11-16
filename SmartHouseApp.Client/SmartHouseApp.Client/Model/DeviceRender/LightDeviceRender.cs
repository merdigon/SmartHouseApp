using SmartHouseApp.Client.Views.Components;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client.Model.DeviceRender
{
    public class LightDeviceRender : LightDeviceViewModel, IDeviceRender
    {
        public UserControl GetConfUserControl()
        {
            return new LightConfUserControl(this);
        }
    }
}
