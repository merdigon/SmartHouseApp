using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.KnowledgeDataStructures
{
    public class SystemDataKnowledge
    {
        public static List<StaticRouterInfo> RoutersInfo
        {
            //get
            //{
            //    return new List<StaticRouterInfo>{
            //        new StaticRouterInfo{
            //            SSID="R1",
            //            Location = new DataStractures.Point{X = 20, Y = 10},
            //            Frequency = 2400
            //        },
            //        new StaticRouterInfo{
            //            SSID = "R2",
            //            Location = new DataStractures.Point{X=10, Y=20},
            //            Frequency = 2400
            //        },
            //        new StaticRouterInfo{
            //            SSID = "R3",
            //            Location = new DataStractures.Point{X=20, Y=30},
            //            Frequency = 2400
            //        }
            //    };
            //}
            get;
            set;
        }

        public static List<DynamicDeviceInfo> DevicesInfo { get; set; }
        public static decimal DistanceToPointConverter { get { return 1M; } }
    }
}
