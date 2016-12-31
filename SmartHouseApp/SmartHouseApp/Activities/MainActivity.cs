using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.Runtime;
using Android.Views;
using Android.OS;
using System.Linq;

namespace SmartHouseApp.Activities
{
    [Activity(Label = "SmartHouseApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public ToggleButton TbButton { get; set; }
        public EditText EtIp { get; set; }
        public EditText EtPort { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            TbButton = FindViewById<ToggleButton>(Resource.Id.tgChangeServiceState);
            EtIp = FindViewById<EditText>(Resource.Id.etIp);
            EtPort = FindViewById<EditText>(Resource.Id.etPort);
            EtPort.Text = "52079";
            EtIp.Text = "192.168.1.105";

            TbButton.Click += tbButton_Click;
        }

        private void tbButton_Click(object sender, EventArgs e)
        {
            if (TbButton.Checked)
            {
                int port;
                if (int.TryParse(EtPort.Text, out port))
                {
                    string[] partsOfIp = EtIp.Text.Split(new char[] { '.' });
                    if (partsOfIp.Length == 4)
                    {
                        int part;
                        if (!partsOfIp.Select(p => int.TryParse(p, out part)).Contains(false))
                        {
                            var serviceIntent = new Intent(this, typeof(LocalizationService));
                            serviceIntent.PutExtra("ip", EtIp.Text);
                            serviceIntent.PutExtra("port", port);
                            StartService(serviceIntent);
                        }
                        else
                        {
                            Toast.MakeText(this, "Niepoprawny format adresu ip!", ToastLength.Long);
                            TbButton.Checked = false;
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Niepoprawny format adresu ip!", ToastLength.Long);
                        TbButton.Checked = false;
                    }
                }
                else
            {
                    Toast.MakeText(this, "Niepoprawny port!", ToastLength.Long);
                    TbButton.Checked = false;
                }
            }
            else
            {
                StopService(new Intent(this, typeof(LocalizationService)));
            }
        }
    }
}

