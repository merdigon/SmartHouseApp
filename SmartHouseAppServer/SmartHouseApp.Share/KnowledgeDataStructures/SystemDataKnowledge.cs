﻿using System;
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
            get
            {
                return new List<StaticRouterInfo>{
                    new StaticRouterInfo{
                        SSID="TP-LINK_7C6432",
                        Location = new DataStractures.Point{X = 0, Y = 0, Z = 0 },
                        AntennaGain = 5,
                        TrasmitterPower = 16.5,
                        FadeMargin = 22
                    },
                    new StaticRouterInfo{
                        SSID = "TP-LINK_ACP",
                        Location = new DataStractures.Point{X=1.80M, Y=0, Z = 0},
                        AntennaGain = 2,
                        FadeMargin = 22,
                        TrasmitterPower = 16
                    },
                    new StaticRouterInfo{
                        SSID = "AndroidAP",
                        Location = new DataStractures.Point{X=1.07M, Y=1.80M,  Z = 0},
                        AntennaGain = 2,
                        FadeMargin = 22,
                        TrasmitterPower = 10
                    }
                };
            }
            set { }
        }

        public static List<DynamicDeviceInfo> DevicesInfo { get; set; }
        public static decimal DistanceToPointConverter { get { return 1M; } }
    }
}
