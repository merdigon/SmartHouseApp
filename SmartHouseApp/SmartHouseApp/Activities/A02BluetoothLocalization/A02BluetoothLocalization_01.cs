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
using SmartHouseApp.DataStractures;
using SmartHouseApp.Activities.A01SearchRouters;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

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
                    SendReceivedInfo(BluetoothDevicesList);
                }
                else if (BluetoothDevice.ActionFound.Equals(action))
                {
                    BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                    int strength = (int)intent.GetShortExtra(BluetoothDevice.ExtraRssi, Short.MinValue);
                    var name = device.Name;

                    BluetoothDevicesList.Add(new BluetoothInfo { Name = name, Stregth = strength });
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
            if (bluetoothsInfo != null)
            {
                Adapter.AddRange(bluetoothsInfo.OrderByDescending(p => p.Stregth).ToList());
                Adapter.NotifyDataSetChanged();
            }
        }

        public void SendReceivedInfo(IList<BluetoothInfo> routersInfo)
        {
            var data = new DeviceNotificationModel();
            data.SourceName = "Telefon";
            data.SignalData = new SignalStrengthDataModel[routersInfo.Count];
            for (int i = 0; i < routersInfo.Count; i++)
            {
                data.SignalData[i] = new SignalStrengthDataModel()
                {
                    DeviceName = routersInfo[i].Name,
                    SignalStrength = routersInfo[i].Stregth,
                    Type = SignalType.BLUETOOTH
                };
            }
            FetchWeatherAsync("http://192.168.1.105:52079/api/DataCollector/ReportDevices/", data);
        }

        private async Task<bool> FetchWeatherAsync(string url, DeviceNotificationModel model)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "POST";
            var json = JsonConvert.SerializeObject(model);
            var data = System.Text.Encoding.ASCII.GetBytes(json);
            request.ContentLength = data.Length;

            using (Stream sw = request.GetRequestStream())
            {
                sw.Write(data, 0, data.Length);
            }

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                }
            }
        }
    }

    public class BluetoothInfo
    {
        public string Name { get; set; }
        public int Stregth { get; set; }
    }
}