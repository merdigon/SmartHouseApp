using SmartHouseApp.Share.DataStractures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.KnowledgeDataStructures
{
    public class StaticRouterInfo
    {
        public string SSID { get; set; }
        public int RssiOnZeroDistance { get; set; }
        public Point Location { get; set; }

        public double GetSigmaForSignalStrength(double signalStrength)
        {
            return 0.2;
        }
    }
}
