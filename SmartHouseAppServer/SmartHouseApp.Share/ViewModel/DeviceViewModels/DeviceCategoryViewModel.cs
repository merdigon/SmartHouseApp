using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.ViewModel.DeviceViewModels
{
    public class DeviceCategoryViewModel
    {
        public string VisibleName { get; set; }
        public DeviceCategories CategoryId { get; set; }
        public string ImageName { get; set; }
    }
}
