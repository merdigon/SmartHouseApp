using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHouseApp.Client.Model.DeviceRender
{
    public interface IDeviceRender
    {
        string VisibleName { get; set; }
        int DeviceId { get; set; }
        UserControl GetConfUserControl();
    }
}
