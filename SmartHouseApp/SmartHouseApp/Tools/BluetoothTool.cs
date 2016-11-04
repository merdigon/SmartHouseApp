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
    public class BluetoothTool
    {
        public static double GetDbmRecalculation(int signalStrenght)
        {
            double fpsi = 4 + 2 + 2 - signalStrenght - 22 - 5;
            return Math.Pow(10, (fpsi + 27.55 - 67.75)/20);
        }
    }
}