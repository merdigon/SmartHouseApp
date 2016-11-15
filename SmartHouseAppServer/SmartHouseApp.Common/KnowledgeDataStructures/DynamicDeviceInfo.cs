﻿using SmartHouseApp.Common.DataStractures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Common.KnowledgeDataStructures
{
    public class DynamicDeviceInfo
    {
        public string BluetoothMac { get; set; }
        public Point CurrentLocation { get; set; }
        public List<SignalStrengthDataModel> CurrentSignalStrengthData { get; set; }
        public DateTime CurrentLocationUpdateTime { get; set; }
    }
}