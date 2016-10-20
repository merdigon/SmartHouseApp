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
    public class MyBroadcastReceiver : BroadcastReceiver
    {
        public MyBroadcastReceiver(OnReceiveDel overrideDelegate)
        {
            OnReceiveDelField = overrideDelegate;
        }

        public delegate void OnReceiveDel(Context context, Intent intent);
        public OnReceiveDel OnReceiveDelField;

        public override void OnReceive(Context context, Intent intent)
        {
            OnReceiveDelField(context, intent);
        }
    }
}