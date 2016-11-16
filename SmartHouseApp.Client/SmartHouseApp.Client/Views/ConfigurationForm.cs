using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHouseApp.Share.ViewModel;
using SmartHouseApp.Client.Tools;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using SmartHouseApp.Client.Model.DeviceRender;

namespace SmartHouseApp.Client.Views
{
    public partial class ConfigurationForm : Form
    {
        public Tuple<int, int> MapSize { get; set; }
        private Form1 MainForm { get; set; }
        public int selectedItemId = 0;
        private List<DeviceCategoryViewModel> Categories { get; set; }
        private DeviceCategoryViewModel SelectedCategory { get; set; }
        private List<IDeviceRender> Devices { get; set; }

        public List<StaticRouterDataViewModel> Routers { get; set; }

        public ConfigurationForm(Form1 mainForm)
        {
            InitializeComponent();

            MainForm = mainForm;
            var mapSize = RestClient.Get<SizeViewModel>("Conf/GetMapSize");
            MapSize = new Tuple<int, int>(mapSize.X, mapSize.Y);

            tbX.Text = MapSize.Item1.ToString();
            tbY.Text = MapSize.Item2.ToString();

            Routers = RestClient.Get<List<StaticRouterDataViewModel>>("Conf/GetRoutersInfo");

            dgvRouters.DataSource = Routers;
        }

        private void btnSaveMapSize_Click(object sender, EventArgs e)
        {
            try
            {
                double x, y;
                if (!double.TryParse(tbX.Text, out x) || !double.TryParse(tbY.Text, out y))
                {
                    InfoForm.ShowWarning("Błędne dane w polach z wielkością mapy!");
                    return;
                }

                var model = new SaveMapSizeModel
                {
                    MapSizeX = (int)x,
                    MapSizeY = (int)y
                };

                if (RestClient.Post<bool>("Conf/SaveMapSize", model))
                {
                    MainForm.MapSize = new Size((int)x, (int)y);
                }
            }
            catch (Exception ex)
            {
                InfoForm.ShowError(ex.Message);
            }
        }

        private void dgvRouters_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = sender as DataGridView;

            StaticRouterDataViewModel selected = null;
            if (grid.SelectedRows.Count > 0)
            {
                selected = (StaticRouterDataViewModel)grid.SelectedRows[0].DataBoundItem;
            }
            else if (grid.SelectedCells.Count > 0)
            {
                selected = (StaticRouterDataViewModel)grid.Rows[grid.SelectedCells[0].RowIndex].DataBoundItem;
            }

            if (selected != null)
            {
                tbAntenaGain.Text = selected.AntennaGain.ToString();
                tbFadeMargin.Text = selected.FadeMargin.ToString();
                tbSsid.Text = selected.SSID;
                tbTransPower.Text = selected.TrasmitterPower.ToString();
                tbXR.Text = selected.LocationX.ToString();
                tbYR.Text = selected.LocationY.ToString();
                tbZR.Text = selected.LocationZ.ToString();
                selectedItemId = selected.Id;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbAntenaGain.Text = "";
            tbFadeMargin.Text = "";
            tbSsid.Text = "";
            tbTransPower.Text = "";
            tbXR.Text = "";
            tbYR.Text = "";
            tbZR.Text = "";
            selectedItemId = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbAntenaGain.Text) &&
                   !string.IsNullOrEmpty(tbFadeMargin.Text) &&
                   !string.IsNullOrEmpty(tbSsid.Text) &&
                   !string.IsNullOrEmpty(tbTransPower.Text) &&
                   !string.IsNullOrEmpty(tbXR.Text) &&
                   !string.IsNullOrEmpty(tbYR.Text) &&
                   !string.IsNullOrEmpty(tbZR.Text))
                {
                    double ag, fm, tp, xr, yr, zr;
                    if (double.TryParse(tbAntenaGain.Text, out ag) &&
                    double.TryParse(tbFadeMargin.Text, out fm) &&
                    double.TryParse(tbTransPower.Text, out tp) &&
                    double.TryParse(tbXR.Text, out xr) &&
                    double.TryParse(tbYR.Text, out yr) &&
                    double.TryParse(tbZR.Text, out zr))
                    {
                        var model = new SaveStaticRouterInfoModel
                        {
                            AntennaGain = ag,
                            FadeMargin = fm,
                            Id = selectedItemId,
                            SSID = tbSsid.Text,
                            TrasmitterPower = tp,
                            LocationX = xr,
                            LocationY = yr,
                            LocationZ = zr
                        };

                        if (RestClient.Post<bool>("Conf/SaveRouterData", model))
                        {
                            Routers = RestClient.Get<List<StaticRouterDataViewModel>>("Conf/GetRoutersInfo");
                            dgvRouters.DataSource = Routers;
                            dgvRouters.Refresh();
                            button1_Click(null, null);
                        }
                    }
                    else
                    {
                        InfoForm.ShowWarning("Błędny format danych!");
                    }
                }
                else
                    InfoForm.ShowWarning("Pola nie mogą być puste!");
            }
            catch (Exception ex)
            {
                InfoForm.ShowError(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedItemId > 0)
                {
                    if (RestClient.Post<bool>("Conf/DeleteRouterData", selectedItemId))
                    {
                        Routers = RestClient.Get<List<StaticRouterDataViewModel>>("Conf/GetRoutersInfo");
                        dgvRouters.DataSource = Routers;
                        dgvRouters.Refresh();
                        button1_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                InfoForm.ShowError(ex.Message);
            }
        }

        private void lvDeviceItemCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDeviceItemCategories.SelectedItems.Count > 0)
            {
                string category = lvDeviceItemCategories.SelectedItems[0].Text;
                if(Categories != null)
                {
                    var categoryObject = Categories.Where(p => p.VisibleName.Equals(category)).SingleOrDefault();
                    if(categoryObject != null)
                    {
                        switch(categoryObject.CategoryId)
                        {
                            case DeviceCategories.Light:
                                Devices = RestClient.Post<List<LightDeviceViewModel>>("Conf/GetLightDevices", null).Select(p => (IDeviceRender)p).ToList();
                                break;
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int deviceId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                if (Devices != null)
                {
                    var deviceObject = Devices.Where(p => p.DeviceId == deviceId).SingleOrDefault();
                    if (deviceObject != null)
                    {
                        gBCategory.Controls.Clear();
                        gBCategory.Controls.Add(deviceObject.GetConfUserControl());
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserControl confUserControl = null;
            if(SelectedCategory.CategoryId == DeviceCategories.Light)
            {
                confUserControl = new LightDeviceRender().GetConfUserControl();
            }
            gBCategory.Controls.Clear();
            gBCategory.Controls.Add(confUserControl);
        }
    }
}
