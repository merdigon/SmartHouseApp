using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseAppServer.Domain
{
    public class LightDeviceDomain
    {
        public virtual int DeviceId { get; set; }
        public virtual string VisibleName { get; set; }
        public virtual string Ip { get; set; }
        public virtual string Port { get; set; }
        public virtual int MinPercentagePower { get; set; }
        public virtual int MaxPercentagePower { get; set; }
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Z { get; set; }
    }
}