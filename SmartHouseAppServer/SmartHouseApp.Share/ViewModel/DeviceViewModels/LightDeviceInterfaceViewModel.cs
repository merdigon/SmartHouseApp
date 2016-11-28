using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.ViewModel.DeviceViewModels
{
    public class LightDeviceInterfaceViewModel
    {
        public virtual int Id { get; set; }
        public virtual string VisibleName { get; set; }

        public override string ToString()
        {
            return VisibleName;
        }

        public override bool Equals(object obj)
        {
            if (obj is LightDeviceInterfaceViewModel)
                return ((LightDeviceInterfaceViewModel)obj).Id == Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
