using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseAppServer.Domain;
using SmartHouseAppServer.App_Start;
using SmartHouseAppServer.DeviceInterfaces.LightDevice;
using System.Reflection;

namespace SmartHouseAppServer.DeviceControllers.LightDevices
{
    public class ImportantUserFirstContr : ILightDeviceContr
    {        
        private DateTime? LastVisiteOfImportant = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userPossitions"></param>
        /// <param name="previousStaticPowerLevel"></param>
        /// <param name="deviceThread"></param>
        /// <returns>Zwraca informację, czy stopień oświetlenia został już ustawiony przez tą metodę</returns>
        public bool ControlDeviceByEvent(List<UserPositionHistory> userPossitions, int previousStaticPowerLevel, DeviceControllingThread deviceThread)
        {
            List<SystemUser> users = deviceThread.SystemUser;
            List<UserPositionHistory> nearPossitions = new List<UserPositionHistory>();
            foreach(var userPoss in userPossitions)
            {
                if (DotNetInterface.iCountDistanceBetweenTwoPoints(deviceThread.LightDevice.X, deviceThread.LightDevice.Y, deviceThread.LightDevice.Z, userPoss.X, userPoss.Y, userPoss.Z) < DeviceControllingThread.DISTANCE_TO_LIGHT_DEVICE)
                    nearPossitions.Add(userPoss);
            }
            List<Tuple<UserPositionHistory, int>> positionsWithUserWeight = new List<Tuple<UserPositionHistory, int>>();
            foreach (var nearPoss in nearPossitions)
            {
                var user = users.Where(p => p.Mac.Equals(nearPoss.Mac)).SingleOrDefault();
                if(user!=null)
                {
                    positionsWithUserWeight.Add(new Tuple<UserPositionHistory, int>(nearPoss, user.UserWeight));
                }
                else
                {
                    positionsWithUserWeight.Add(new Tuple<UserPositionHistory, int>(nearPoss, 1));
                }
            }
            var iuPossitions = positionsWithUserWeight.Where(p => p.Item2 == 4).ToList();

            if(iuPossitions.Count() > 0)
            {
                ILightDeviceInterface ldInterface = (ILightDeviceInterface)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name, deviceThread.LightDevice.Interface.InterfaceClassName);
                ldInterface.NotifyInformationToDevice(deviceThread.LightDevice.Ip, deviceThread.LightDevice.Port, deviceThread.LightDevice.MaxPercentagePower);
                LastVisiteOfImportant = DateTime.Now;
                return true;
            }
            else
            {
                if (!LastVisiteOfImportant.HasValue)
                    return false;
                else if(LastVisiteOfImportant.Value.AddSeconds(5) < DateTime.Now)
                    return true;
                else
                {
                    ILightDeviceInterface ldInterface = (ILightDeviceInterface)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name, deviceThread.LightDevice.Interface.InterfaceClassName);
                    ldInterface.NotifyInformationToDevice(deviceThread.LightDevice.Ip, deviceThread.LightDevice.Port, previousStaticPowerLevel);
                    LastVisiteOfImportant = null;
                    return false;
                }
            }
        }
    }
}