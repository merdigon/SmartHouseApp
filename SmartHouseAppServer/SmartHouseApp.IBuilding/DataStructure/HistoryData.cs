using SmartHouseApp.Common.DataStractures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.IBuilding.DataStructure
{
    public class HistoryData
    {
        public Point DeviceLocalization { get; set; }
        public string DeviceName { get; set; }
        public DateTime DateOfLocalization { get; set; }
    }
}
