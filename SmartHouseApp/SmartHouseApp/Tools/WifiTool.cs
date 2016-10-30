using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SmartHouseApp.Tools
{
    public static class WifiTool
    {
        public static double GetDistanceRecalculation(double fadeMargin, double transmitterPower, double antenaGainTransmitter, int signalStrenght)
        {
            double deviceAtennaGain = 2;
            double fspl = transmitterPower + antenaGainTransmitter + deviceAtennaGain - fadeMargin - signalStrenght;
            double toPow = ((fspl + 27.55 - 67.75) / 20);
            return Math.Pow(10, toPow);
            //return Math.Pow(10.0, ((fspl - (-46.0)) / (-10.0 * 5.0)));
        }
    }
}