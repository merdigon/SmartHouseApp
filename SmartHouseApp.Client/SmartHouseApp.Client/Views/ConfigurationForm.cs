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
using SmartHouseApp.Client.Views.Components;
using SmartHouseApp.Client.Properties;

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
        private List<SystemUserViewModel> SystemUsers { get; set; }

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
            cbRouterCategory.DataSource = RestClient.Get<List<RouterTypeViewModel>>("Conf/GetRouterTypes");

            ilDeviceImages.Images.AddRange(new[] { Resources.Light_On_48px, Resources.Temperature_48px });
            lvDeviceItemCategories.SmallImageList = ilDeviceImages;
            lvDeviceItemCategories.Columns.Add("Kategoria", -2, HorizontalAlignment.Center);
            lvDeviceItemCategories.View = View.Details;
            listView1.Columns.Add("Id", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("Nazwa", -2, HorizontalAlignment.Center);
            listView1.View = View.Details;
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
                tbSsid.Text = selected.SSID;
                tbTransPower.Text = selected.TrasmitterPower.ToString();
                tbXR.Text = selected.LocationX.ToString();
                tbYR.Text = selected.LocationY.ToString();
                tbZR.Text = selected.LocationZ.ToString();
                selectedItemId = selected.Id;
                cbRouterCategory.SelectedIndex = selected.RouterCategoryId - 1;
                tbWeight.Text = selected.Weight.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbAntenaGain.Text = "";
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
                   !string.IsNullOrEmpty(tbSsid.Text) &&
                   !string.IsNullOrEmpty(tbTransPower.Text) &&
                   !string.IsNullOrEmpty(tbXR.Text) &&
                   !string.IsNullOrEmpty(tbYR.Text) &&
                   !string.IsNullOrEmpty(tbZR.Text) &&
                   !string.IsNullOrEmpty(tbWeight.Text))
                {
                    double ag, tp, xr, yr, zr;
                    int weight;
                    if (double.TryParse(tbAntenaGain.Text, out ag) &&
                    double.TryParse(tbTransPower.Text, out tp) &&
                    double.TryParse(tbXR.Text, out xr) &&
                    double.TryParse(tbYR.Text, out yr) &&
                    double.TryParse(tbZR.Text, out zr) &&
                    int.TryParse(tbWeight.Text, out weight))
                    {
                        if (weight > 0 && weight <= 4)
                        {
                            var model = new SaveStaticRouterInfoModel
                            {
                                AntennaGain = ag,
                                Id = selectedItemId,
                                SSID = tbSsid.Text,
                                TrasmitterPower = tp,
                                LocationX = xr,
                                LocationY = yr,
                                LocationZ = zr,
                                Weight = weight,
                                RouterCategoryId = cbRouterCategory.SelectedIndex + 1
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
                            InfoForm.ShowWarning("Waga urządzenia musi być z przedziału 1-4!");
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
                    SelectedCategory = Categories.Where(p => p.VisibleName.Equals(category)).SingleOrDefault();
                    if(SelectedCategory != null)
                    {
                        switch(SelectedCategory.CategoryId)
                        {
                            case (int)DeviceCategories.LIGHT:
                                Devices = RestClient.Post<List<LightDeviceViewModel>>("Conf/GetLightDevices", null).Select(p => (IDeviceRender)new LightDeviceRender
                                {
                                    DeviceId = p.DeviceId,
                                    Ip = p.Ip,
                                    MaxPercentagePower = p.MaxPercentagePower,
                                    MinPercentagePower = p.MinPercentagePower,
                                    Port = p.Port,
                                    VisibleName = p.VisibleName,
                                    X = p.X,
                                    Y = p.Y,
                                    Z = p.Z,
                                    Active = p.Active,
                                    Interface = p.Interface
                                }).ToList();
                                break;
                            default:
                                Devices.Clear();
                                break;
                        }

                        listView1.Items.Clear();
                        if (Devices.Count > 0)
                        {
                            ListViewItem[] arrayWithDevices = new ListViewItem[Devices.Count];
                            for (int i = 0; i < Devices.Count; i++)
                            {
                                var item = new ListViewItem(Devices[i].DeviceId.ToString());
                                item.SubItems.Add(Devices[i].VisibleName);
                                arrayWithDevices[i] = item;
                            }
                            listView1.Items.AddRange(arrayWithDevices);
                        }
                        listView1.Refresh();
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
            if(SelectedCategory.CategoryId == (int)DeviceCategories.LIGHT)
            {
                confUserControl = new LightDeviceRender().GetConfUserControl();
            }
            gBCategory.Controls.Clear();
            gBCategory.Controls.Add(confUserControl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach(var control in gBCategory.Controls)
            {
                if(control is IDeviceConfControl)
                {
                    ((IDeviceConfControl)control).Save();
                }
            }
            lvDeviceItemCategories_SelectedIndexChanged(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int deviceId = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                if (Devices != null)
                {
                    var deviceObject = Devices.Where(p => p.DeviceId == deviceId).SingleOrDefault();
                    if (deviceObject != null)
                    {
                        if (RestClient.Post<bool>("Conf/DeleteLightDevice", deviceObject))
                            InfoForm.ShowWarning("Pomyślnie usunięto urządzenie");
                        lvDeviceItemCategories_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            lvDeviceItemCategories.Items.Clear();
            Categories = RestClient.Get<List<DeviceCategoryViewModel>>("Conf/GetDeviceCategories");
            ListViewItem[] arrayWithCategories = new ListViewItem[Categories.Count];
            for(int i=0;i<Categories.Count;i++)
            {
                var item = new ListViewItem(Categories[i].VisibleName, Categories[i].CategoryId - 1);
                item.SubItems.Add(Categories[i].VisibleName);
                arrayWithCategories[i] = item;
            }
            lvDeviceItemCategories.Items.AddRange(arrayWithCategories);
            lvDeviceItemCategories.Refresh();
        }

        private void cbRouterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRouterCategory.SelectedIndex == 0)
                tbWeight.Text = 3.ToString();
            else
                tbWeight.Text = 2.ToString();
        }

        private void tsbRefreshUsers_Click(object sender, EventArgs e)
        {
            SystemUsers = RefreshUsers();
            dgvUsers.DataSource = SystemUsers;
            dgvUsers.Refresh();
        }

        private List<SystemUserViewModel> RefreshUsers()
        {
            return RestClient.Get<List<SystemUserViewModel>>("Conf/GetAllUsers");
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            SystemUsers = RefreshUsers();
            dgvUsers.DataSource = SystemUsers;
            dgvUsers.Refresh();
        }

        private void tsbSaveUsers_Click(object sender, EventArgs e)
        {
            int weight;

            List<SystemUserViewModel> tempUserList = new List<SystemUserViewModel>();
            for(int i=0;i < dgvUsers.Rows.Count; i++)
            {
                SystemUserViewModel newUser = new SystemUserViewModel
                {
                    Id = (int)dgvUsers.Rows[i].Cells[0].Value,
                    VisibleName = (string)dgvUsers.Rows[i].Cells[1].Value,
                    Mac = (string)dgvUsers.Rows[i].Cells[2].Value,
                    Weight = (string)dgvUsers.Rows[i].Cells[3].EditedFormattedValue
                };
                tempUserList.Add(newUser);
            }

            SystemUsers = tempUserList;
            foreach(var user in SystemUsers)
            {
                if (string.IsNullOrEmpty(user.Weight) || !int.TryParse(user.Weight, out weight))
                {
                    InfoForm.ShowError("Conajmniej jeden z użytkowników ma błędną wagę!");
                    return;
                }
            }

            if (RestClient.Post<bool>("Conf/SaveUsers", SystemUsers))
                InfoForm.ShowWarning("Pomyślnie zapisano użytkowników!");
        }
    }
}
