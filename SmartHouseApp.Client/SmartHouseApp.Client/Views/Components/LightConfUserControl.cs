using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHouseApp.Client.Model.DeviceRender;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using SmartHouseApp.Client.Tools;

namespace SmartHouseApp.Client.Views.Components
{
    public partial class LightConfUserControl : UserControl, IDeviceConfControl
    {
        LightDeviceRender model = null;

        public LightConfUserControl(LightDeviceRender model)
        {
            InitializeComponent();

            this.model = model;
            tbIp.Text = model.Ip;
            tbPort.Text = model.Port;
            tbMaxPerc.Text = model.MaxPercentagePower.ToString();
            tbMinPerc.Text = model.MinPercentagePower.ToString();
            tbVisibleName.Text = model.VisibleName;
            tbX.Text = model.X.ToString();
            tbY.Text = model.Y.ToString();
            tbZ.Text = model.Z.ToString();
            tbScope.Text = model.Scope.ToString();
            cbIsActive.Checked = model.Active;

            cmbEventHandler.DataSource = new string[] { "Brak", "ImportantUserFirstContr" };
            cmbEventHandler.SelectedItem = model.ControllModule;

            var possibleLightDeviceInterfaces = RestClient.Get<List<LightDeviceInterfaceViewModel>>("Conf/LightDeviceInterfaces");
            cbLightDeviceInterface.Items.AddRange(possibleLightDeviceInterfaces.ToArray());
            if (model.Interface != null)
                cbLightDeviceInterface.SelectedItem = possibleLightDeviceInterfaces.Where(p => p.Id == model.Interface.Id).Single();
        }

        public bool Save()
        {
            int max, min;
            double x, y, z, scope;

            if (int.TryParse(tbMaxPerc.Text, out max) &&
                int.TryParse(tbMinPerc.Text, out min) &&
                double.TryParse(tbX.Text, out x) &&
                double.TryParse(tbY.Text, out y) &&
                double.TryParse(tbZ.Text, out z) &&
                double.TryParse(tbScope.Text, out scope))
            {
                string choosenModule = cmbEventHandler.SelectedItem as string;

                var model = new LightDeviceViewModel
                {
                    DeviceId = this.model.DeviceId,
                    Ip = tbIp.Text,
                    MaxPercentagePower = max,
                    MinPercentagePower = min,
                    Port = tbPort.Text,
                    VisibleName = tbVisibleName.Text,
                    X = x,
                    Y = y,
                    Z = z,
                    Scope = scope,
                    Active = cbIsActive.Checked,
                    ControllModule = (string.IsNullOrEmpty(choosenModule) ? null : (choosenModule.Equals("Brak") ? null : choosenModule))
                };

                LightDeviceInterfaceViewModel choosenInterface = cbLightDeviceInterface.SelectedItem as LightDeviceInterfaceViewModel;
                if (choosenInterface != null)
                    model.Interface = new LightDeviceInterfaceViewModel { Id = choosenInterface.Id };

                return RestClient.Post<bool>("Conf/SaveLightDevice", model);
            }
            else
            {
                InfoForm.ShowError("Błąd danych!");
                return false;
            }
        }
    }
}
