using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseAppServer.DeviceInterfaces.LightDevice
{
    public interface ILightDeviceInterface
    {
        bool NotifyInformationToDevice(string ip, string port, int percentage);
    }
}
