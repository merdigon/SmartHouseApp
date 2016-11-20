using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseAppServer.Domain
{
    public class LightDeviceDomain
    {
        public int DeviceId { get; set; }
        public string VisibleName { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public int MinPercentagePower { get; set; }
        public int MaxPercentagePower { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}