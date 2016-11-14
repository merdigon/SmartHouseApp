using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.ViewModel
{
    public class StaticRouterDataViewModel
    {
        public int Id { get; set; }
        public string SSID { get; set; }
        public double TrasmitterPower { get; set; }
        public double AntennaGain { get; set; }
        public double FadeMargin { get; set; }
        public decimal LocationX { get; set; }
        public decimal LocationY { get; set; }
        public decimal LocationZ { get; set; }
    }
}
