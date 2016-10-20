using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.Runtime;
using Android.Views;
using Android.OS;
using SmartHouseApp.Activities.A01SearchRouters;
using SmartHouseApp.Activities.A02BluetoothLocalization;

namespace SmartHouseApp.Activities
{
    [Activity(Label = "SmartHouseApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button SearchRoutersButton { get; set; }
        Button SearchBluetoothButton { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            SearchRoutersButton = FindViewById<Button>(Resource.Id.SearchRouters);
            SearchBluetoothButton = FindViewById<Button>(Resource.Id.SearchBluetooths);

            SearchRoutersButton.Click += delegate
            {
                StartActivity(typeof(A01SearchRouters_01));
            };

            SearchBluetoothButton.Click += delegate
            {
                StartActivity(typeof(A02BluetoothLocalization_01));
            };
        }
    }
}

