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
using SmartHouseApp.Tools;
using Android.Net.Wifi;
using SmartHouseApp.Adapters;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Org.Json;
using Newtonsoft.Json;
using SmartHouseApp.DataStractures;

namespace SmartHouseApp.Activities.A01SearchRouters
{
    [Activity(Label = "A01SearchRouters_01")]
    public class A01SearchRouters_01 : Activity
    {
        MyBroadcastReceiver Receiver { get; set; }
        WifiManager LocalWifiManager { get; set; }
        ToggleButton TbUpdateRoutersList { get; set; }
        IList<RouterInfo> RoutersInfo { get; set; }
        ListView RouterListView { get; set; }
        SimpleRoutersInfoAdapter Adapter { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.A01SearchRouter);
            RoutersInfo = new List<RouterInfo>();

            TbUpdateRoutersList = (ToggleButton)FindViewById<ToggleButton>(Resource.Id.tbUpdateRouters);
            RouterListView = (ListView)FindViewById<ListView>(Resource.Id.routersList);
            Adapter = new SimpleRoutersInfoAdapter(this, RoutersInfo);
            RouterListView.Adapter = Adapter;

            LocalWifiManager = (WifiManager)GetSystemService(Context.WifiService);
            Receiver = new MyBroadcastReceiver((Context c, Intent intent) =>
            {
                if (intent.Action.Equals(WifiManager.ScanResultsAvailableAction) && TbUpdateRoutersList.Checked)
                {
                    IList<ScanResult> mScanResults = LocalWifiManager.ScanResults;
                    IList<RouterInfo> resultInfo = new List<RouterInfo>();
                    foreach (ScanResult result in mScanResults)
                    {
                        resultInfo.Add(new RouterInfo { Name = result.Ssid, Distance = WifiTool.GetDistanceRecalculation(22.0, 10.0, 2.0, result.Level), Strenght = result.Level });
                    }
                    UpdateRoutersList(resultInfo);
                    SendReceivedInfo(resultInfo);
                }
            });
            RegisterReceiver(Receiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            RegisterUpdatingThread();
            TbUpdateRoutersList.Click += TbUpdateRoutersList_Click;
        }

        private void TbUpdateRoutersList_Click(object sender, EventArgs e)
        {
            if (TbUpdateRoutersList.Checked)
                RegisterReceiver(Receiver, new IntentFilter(WifiManager.ScanResultsAvailableAction));
            else
                UnregisterReceiver(Receiver);
        }

        private void RegisterUpdatingThread()
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (true)
                {
                    if (TbUpdateRoutersList.Checked)
                    {
                        LocalWifiManager.StartScan();
                        Thread.Sleep(2000);
                    }
                }
            });
        }

        public void UpdateRoutersList(IList<RouterInfo> routersInfo)
        {
            Adapter.ClearItems();
            Adapter.AddRange(routersInfo.OrderByDescending(p => p.Strenght).ToList());
            Adapter.NotifyDataSetChanged();
        }

        public void SendReceivedInfo(IList<RouterInfo> routersInfo)
        {
            var data = new DeviceNotificationModel();
            data.SourceName = "Telefon";
            data.SignalData = new SignalStrengthDataModel[routersInfo.Count];
            for (int i = 0; i < routersInfo.Count;i++)
            {
                data.SignalData[i] = new SignalStrengthDataModel(){
                    DeviceName = routersInfo[i].Name,
                    SignalStrength = routersInfo[i].Strenght,
                    Type = SignalType.WIFI
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
            var data = Encoding.ASCII.GetBytes(json);
            request.ContentLength = data.Length;

            using(Stream sw = request.GetRequestStream())
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

    public class RouterInfo
    {
        public string Name { get; set; }
        public int Strenght { get; set; }
        public double Distance { get; set; }
    }
}