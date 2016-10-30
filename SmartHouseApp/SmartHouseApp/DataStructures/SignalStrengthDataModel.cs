using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.DataStractures
{
    public class SignalStrengthDataModel
    {
        public SignalType Type { get; set; }
        public string DeviceName { get; set; }
        public double SignalStrength { get; set; }
    }
}
