using SmartHouseApp.Client.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Client.Model
{
    public static class RenderTools
    {
        public static Bitmap GetImageForDevice(int deviceCategory)
        {
            switch (deviceCategory)
            {
                case 1:
                    return Resources.Light_On_48px;
                case 2:
                    return Resources.Temperature_48px;
                default:
                    return Resources.error_96px;
            }
        }
    }
}
