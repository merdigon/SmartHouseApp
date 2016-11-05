using SmartHouseApp.Share.DataStractures;
using SmartHouseApp.Share.KnowledgeDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.Tools
{
    public static class WifiTool
    {
        static double SMARTPHONE_WIFI_ANTENNA_GAIN = 2;
        //public static decimal GetDistanceInPoints(int signalStrength, decimal frequency)
        //{
        //    double power = (Math.Abs(signalStrength) - (20 * Math.Log10((double)frequency)) + K) / 20;
        //    double distanceInMeters = Math.Pow(10, power);
        //    return (decimal)distanceInMeters / SystemDataKnowledge.DistanceToPointConverter;
        //}

        public static List<SphereData> GetRouterSphereData(List<SignalStrengthDataModel> routerSignals)
        {
            List<SphereData> dataToCalculate = new List<SphereData>();
            foreach (var ssData in routerSignals)
            {
                var wifiStaticData = SystemDataKnowledge.RoutersInfo.Where(p => p.SSID.Equals(ssData.DeviceName)).FirstOrDefault();
                if (wifiStaticData != null)
                {
                    SphereData data = new SphereData()
                    {
                        X = (double)wifiStaticData.Location.X,
                        Y = (double)wifiStaticData.Location.Y,
                        Z = (double)wifiStaticData.Location.Z,
                        Distance = DotNetInterface.iCountDistanceForWifiRouter(wifiStaticData.FadeMargin, wifiStaticData.TrasmitterPower,
                                                                                wifiStaticData.AntennaGain, ssData.SignalStrength, SMARTPHONE_WIFI_ANTENNA_GAIN, 0),
                        Sigma = wifiStaticData.GetSigmaForSignalStrength(ssData.SignalStrength)
                    };
                    dataToCalculate.Add(data);
                }
            }
            return dataToCalculate;
        }
    }
}
