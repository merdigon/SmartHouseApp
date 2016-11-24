using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Tester
{
    public class StaticRouterInfo
    {
        public int Id { get; set; }
        public string SSID { get; set; }
        public double TrasmitterPower { get; set; }
        public double AntennaGain { get; set; }
        public double FadeMargin { get; set; }
        public Point Location { get; set; }

        public double GetSigmaForSignalStrength(double signalStrength)
        {
            return 0.5;
        }
    }
}
