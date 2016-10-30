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
        public static double GetDistanceRecalculation(int signalStrenght)
        {
            return Math.Pow(10.0, ((signalStrenght - (-46.0)) / (-10.0 * 5.0)));
        }
    }
}