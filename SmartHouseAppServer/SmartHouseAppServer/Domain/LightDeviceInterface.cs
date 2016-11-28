using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseAppServer.Domain
{
    public class LightDeviceInterface
    {
        public virtual int Id { get; set; }
        public virtual string VisibleName { get; set; }
        public virtual string InterfaceClassName { get; set; }
    }
}