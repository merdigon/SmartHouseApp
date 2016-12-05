using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.ViewModel.DeviceViewModels
{
    public class LightDeviceViewModel
    {
        public int DeviceId { get; set; }
        public int CategoryId { get { return 1; } }
        public string VisibleName { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public int MinPercentagePower { get; set; }
        public int MaxPercentagePower { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public bool Active { get; set; }
        public LightDeviceInterfaceViewModel Interface { get; set; }
        public string ControllModule { get; set; }
    }
}
