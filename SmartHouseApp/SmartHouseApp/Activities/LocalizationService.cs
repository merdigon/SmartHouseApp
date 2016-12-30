using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using SmartHouseApp.DataStractures;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Android.Net.Wifi;
using SmartHouseApp.Tools;
using Android.Bluetooth;
using Java.Lang;

namespace SmartHouseApp.Activities
{
    [Service]
    public class LocalizationService : Service
    {
        List<SignalStrengthDataModel> Signals { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public Uri Uri { get; set; }
        public WifiManager LocalWifiManager { get; set; }
        public IntentFilter filter = new IntentFilter();
        public MyBroadcastReceiver WiFiReceiver { get; set; }
        public BluetoothBroadcastReceiver BluetoothReceiver { get; set; }
        public BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
        public List<SignalStrengthDataModel> BluetoothDevicesList { get; set; }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Signals = new List<SignalStrengthDataModel>();
            Ip = intent.GetStringExtra("ip");
            Port = intent.GetIntExtra("port", 8080);
            Uri = new Uri("http://" + Ip + ":" + Port.ToString() + "/api/DataCollector/ReportDevices/");

            LocalWifiManager = (WifiManager)GetSystemService(Context.WifiService);
            WiFiReceiver = new MyBroadcastReceiver((Context c, Intent brIntent) =>
            {
                if (brIntent.Action.Equals(WifiManager.ScanResultsAvailableAction))
                {
                    IList<ScanResult> mScanResults = LocalWifiManager.ScanResults;
                    IList<SignalStrengthDataModel> resultInfo = new List<SignalStrengthDataModel>();
                    foreach (ScanResult result in mScanResults)
                    {
                        resultInfo.Add(new SignalStrengthDataModel { DeviceName = result.Ssid, SignalStrength = result.Level, Type = SignalType.WIFI });
                    }

                    if (Signals.Where(p => p.Type == SignalType.WIFI).Count() == 0)
                        Signals.AddRange(resultInfo);
                }
            });
            RegisterReceiver(WiFiReceiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));

            BluetoothReceiver = new BluetoothBroadcastReceiver((Context c, Intent bluetoothIntent) =>
            {
                string action = bluetoothIntent.Action;
                if (BluetoothAdapter.ActionDiscoveryStarted.Equals(action))
                {
                    BluetoothDevicesList = new List<SignalStrengthDataModel>();
                }
                else if (BluetoothAdapter.ActionDiscoveryFinished.Equals(action))
                {
                    if (Signals.Where(p => p.Type == SignalType.BLUETOOTH).Count() == 0)
                        Signals.AddRange(BluetoothDevicesList);
                    BluetoothDevicesList.Clear();
                }
                else if (BluetoothDevice.ActionFound.Equals(action))
                {
                    BluetoothDevice device = (BluetoothDevice)bluetoothIntent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                    int strength = (int)bluetoothIntent.GetShortExtra(BluetoothDevice.ExtraRssi, Short.MinValue);
                    var name = device.Name;

                    BluetoothDevicesList.Add(new SignalStrengthDataModel { DeviceName = name, SignalStrength = strength, Type = SignalType.BLUETOOTH });
                }
            });

            filter.AddAction(BluetoothDevice.ActionFound);
            filter.AddAction(BluetoothAdapter.ActionDiscoveryStarted);
            filter.AddAction(BluetoothAdapter.ActionDiscoveryFinished);

            RegisterReceiver(BluetoothReceiver, filter);
            RegisterSendingThread();

            return base.OnStartCommand(intent, flags, startId);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        private void RegisterSendingThread()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (true)
                {
                    adapter.StartDiscovery();
                    LocalWifiManager.StartScan();
                    if (Signals.Count > 0)
                    {
                        var signalModel = new List<SignalStrengthDataModel>();
                        signalModel.AddRange(Signals);
                        Signals.Clear();
                        SendToServer(signalModel);
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }
        private async Task<bool> SendToServer(List<SignalStrengthDataModel> models)
        {
            var model = new DeviceNotificationModel { SignalData = models.ToArray(), SourceName = Android.Provider.Settings.Secure.GetString(this.ContentResolver, "bluetooth_address") };
        
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Uri);
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
        public override void OnDestroy()
        {
            UnregisterReceiver(WiFiReceiver);

            base.OnDestroy();
        }
    }
}