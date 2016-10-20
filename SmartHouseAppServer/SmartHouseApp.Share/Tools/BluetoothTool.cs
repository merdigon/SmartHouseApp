using SmartHouseApp.Share.DataStractures;
using SmartHouseApp.Share.KnowledgeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.Tools
{
    public static class BluetoothTool
    {
        static double K = 27.55;
        public static decimal GetDistanceInPoints(int signalStrength, decimal frequency)
        {
            return 5M;
        }

        public static List<SphereData> GetBluetoothSphereData(List<SignalStrengthDataModel> bluetoothSignals)
        {
            var bluetoothDevicesWithPreciseLocalization = SystemDataKnowledge.DevicesInfo.Where(p => p.CurrentLocation != null
                && ((DateTime.Now - p.CurrentLocationUpdateTime) < TimeSpan.FromSeconds(5))).ToList();

            List<SphereData> dataToCount = new List<SphereData>();
            foreach(var nearBDevice in bluetoothSignals)
            {
                var device = bluetoothDevicesWithPreciseLocalization.Where(p => p.BluetoothMac.Equals(nearBDevice.DeviceName)).FirstOrDefault();

                if(device != null)
                {
                    dataToCount.Add(
                        new SphereData
                        {
                            X = (double)device.CurrentLocation.X,
                            Y = (double)device.CurrentLocation.Y,
                            Distance = (double)GetDistanceInPoints(nearBDevice.SignalStrength, 10M)
                        });
                }
            }
            return dataToCount;
        }
    }
}
