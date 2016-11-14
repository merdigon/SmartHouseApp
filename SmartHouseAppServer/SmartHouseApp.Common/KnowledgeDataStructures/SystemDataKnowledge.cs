
using SmartHouseApp.Common.KnowledgeDataStructures;
using SmartHouseApp.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Common.KnowledgeDataStructures
{
    public class SystemDataKnowledge
    {
        static SystemDataKnowledge()
        {
            LoggedUsers = new List<LoggedUser>();
            DevicesInfo = new List<DynamicDeviceInfo>();
            RoutersInfo = Configuration.Conf.RoutersInfo;
            MapSize = new Tuple<int, int>(Configuration.Conf.MapSizeX, Configuration.Conf.MapSizeY);
        }

        public static List<StaticRouterInfo> RoutersInfo { get; set; }

        public static List<DynamicDeviceInfo> DevicesInfo { get; set; }
        public static Tuple<int, int> MapSize { get; set; }
        public static List<LoggedUser> LoggedUsers { get; set; }
    }
}
