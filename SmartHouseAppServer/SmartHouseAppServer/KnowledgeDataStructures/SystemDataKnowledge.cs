using SmartHouseApp.Common.Repository;
using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseAppServer.KnowledgeDataStructures
{
    public class SystemDataKnowledge
    {
        static SystemDataKnowledge()
        {
            LoggedUsers = new List<LoggedUser>();
            DevicesInfo = new List<DynamicDeviceInfo>();
            RoutersInfo = LoadRouterInfo();
            MapSize = new Tuple<double, double>(SmartHouseAppServer.Tools.Configuration.Conf.MapSizeX, SmartHouseAppServer.Tools.Configuration.Conf.MapSizeY);
        }

        public static List<StaticRouterInfo> RoutersInfo { get; set; }

        public static List<DynamicDeviceInfo> DevicesInfo { get; set; }
        public static Tuple<double, double> MapSize { get; set; }
        public static List<LoggedUser> LoggedUsers { get; set; }

        public static List<StaticRouterInfo> LoadRouterInfo()
        {
            using (var repo = new Repository<StaticRouterInfo>())
            {
                return repo.All();
            }
        }
    }
}
