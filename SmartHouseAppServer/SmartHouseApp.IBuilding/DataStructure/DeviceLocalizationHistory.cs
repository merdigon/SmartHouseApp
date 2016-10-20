using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.IBuilding.DataStructure
{
    public class DeviceLocalizationHistory
    {
        public static List<HistoryData> History { get; set; }

        static DeviceLocalizationHistory()
        {
            History = new List<HistoryData>();
        }
    }
}
