using SmartHouseAppServer.App_Start;
using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseAppServer.DeviceControllers.LightDevices
{
    public interface ILightDeviceContr
    {
        bool ControlDeviceByEvent(List<UserPositionHistory> userPossitions, int previousStaticPowerLevel, LightDeviceControllingThread deviceThread);
    }
}
