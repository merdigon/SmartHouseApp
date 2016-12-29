using SmartHouseApp.Common.DataStractures;
using SmartHouseAppServer.KnowledgeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseAppServer.Tools
{
    public static class BluetoothTool
    {
        static double K = 27.55;
        static double SMARTPHONE_WIFI_ANTENNA_GAIN = 2;
        //static double FADE_MARGIN = 22;
        static double ANTENNA_GAIN = 0;
        static double TRANSMITTER_POWER = 6;

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
                            Weight = 1,
                            Distance = DotNetInterface.iCountDistanceForWifiRouter(TRANSMITTER_POWER,
                                                                                ANTENNA_GAIN, nearBDevice.SignalStrength, SMARTPHONE_WIFI_ANTENNA_GAIN, 31)
                        });
                }
                else
                {
                    var staticDevice = SystemDataKnowledge.RoutersInfo.Where(p => p.SSID.Equals(nearBDevice.DeviceName)).SingleOrDefault();

                    if(staticDevice != null)
                    {
                        dataToCount.Add(new SphereData
                        {
                            X = (double)staticDevice.LocationX,
                            Y = (double)staticDevice.LocationY,
                            Z = (double)staticDevice.LocationZ,
                            Weight = staticDevice.Weight,
                            Distance = DotNetInterface.iCountDistanceForWifiRouter(staticDevice.TrasmitterPower,
                                                                                staticDevice.AntennaGain, nearBDevice.SignalStrength, SMARTPHONE_WIFI_ANTENNA_GAIN, 22),
                            Sigma = staticDevice.GetSigmaForSignalStrength(nearBDevice.SignalStrength)
                        });
                    }
                }
            }
            return dataToCount;
        }
    }
}
