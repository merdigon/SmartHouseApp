using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class DeviceNotificationModel
    {
        public string SourceName { get; set; }
        public SignalStrengthDataModel[] SignalData { get; set; }
    }
}
