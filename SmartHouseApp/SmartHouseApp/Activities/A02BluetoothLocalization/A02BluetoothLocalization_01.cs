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
using Android.Locations;
using Android.Bluetooth;
using SmartHouseApp.Tools;
using Java.Lang;
using SmartHouseApp.Adapters;
using System.Threading;

namespace SmartHouseApp.Activities.A02BluetoothLocalization
{
    [Activity(Label = "A02BluetoothLocalization_01")]
    public class A02BluetoothLocalization_01 : Activity
    {
        BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
        IntentFilter filter = new IntentFilter();
        BluetoothBroadcastReceiver mReceiver;
        List<BluetoothInfo> BluetoothDevicesList;
        ToggleButton TbUpdateBluetoothList { get; set; }
        ListView RouterListView { get; set; }
        SimpleBluetoothInfoAdapter Adapter { get; set; }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.A02BlouetoothLocalization);

            TbUpdateBluetoothList = (ToggleButton)FindViewById<ToggleButton>(Resource.Id.tbUpdateBluetooth);
            RouterListView = (ListView)FindViewById<ListView>(Resource.Id.bluetoothList);
            Adapter = new SimpleBluetoothInfoAdapter(this, new List<BluetoothInfo>());
            RouterListView.Adapter = this.Adapter;

            mReceiver = new BluetoothBroadcastReceiver((Context c, Intent intent) =>
            {
                string action = intent.Action;
                if(BluetoothAdapter.ActionDiscoveryStarted.Equals(action))
                {
                    BluetoothDevicesList = new List<BluetoothInfo>();
                }
                else if(BluetoothAdapter.ActionDiscoveryFinished.Equals(action))
                {
                    UpdateBluetoothsList(BluetoothDevicesList);
                }
                else if (BluetoothDevice.ActionFound.Equals(action))
                {
                    BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                    int rssi = BluetoothTool.GetDbmRecalculation(intent.GetShortExtra(BluetoothDevice.ExtraRssi, Short.MinValue));
                    var name = device.Name;

                    BluetoothDevicesList.Add(new BluetoothInfo { Name = name, Strenght = rssi });
                }
            });

            filter.AddAction(BluetoothDevice.ActionFound);
            filter.AddAction(BluetoothAdapter.ActionDiscoveryStarted);
            filter.AddAction(BluetoothAdapter.ActionDiscoveryFinished);

            RegisterReceiver(mReceiver, filter);
            RegisterUpdatingThread();
            TbUpdateBluetoothList.Click += TbUpdateBluetoothsList_Click;
        }

        private void RegisterUpdatingThread()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (true)
                {
                    if (TbUpdateBluetoothList.Checked)
                    {
                        adapter.StartDiscovery();
                        System.Threading.Thread.Sleep(2000);
                    }
                }
            });
        }

        private void TbUpdateBluetoothsList_Click(object sender, EventArgs e)
        {
            if (TbUpdateBluetoothList.Checked)
                RegisterReceiver(mReceiver, filter);
            else
                UnregisterReceiver(mReceiver);
        }

        public void UpdateBluetoothsList(IList<BluetoothInfo> bluetoothsInfo)
        {
            Adapter.ClearItems();
            Adapter.AddRange(bluetoothsInfo.OrderByDescending(p => p.Strenght).ToList());
            Adapter.NotifyDataSetChanged();
        }
    }

    public class BluetoothInfo
    {
        public string Name { get; set; }
        public int Strenght { get; set; }
    }
}