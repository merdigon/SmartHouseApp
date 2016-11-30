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
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double LocationZ { get; set; }
        public int RouterCategoryId { get; set; }
        public int Weight { get; set; }
    }
}
