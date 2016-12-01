using SmartHouseApp.Common.Repository;
using SmartHouseAppServer.DeviceControllers.LightDevices;
using SmartHouseAppServer.DeviceInterfaces.LightDevice;
using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Xml.Serialization;

namespace SmartHouseAppServer.App_Start
{
    public class DeviceControllingThread
    {
        public DateTime LastUpdate { get; set; }
        public Thread CurrentThread { get; set; }
        public LightDeviceDomain LightDevice { get; set; }
        public List<SystemUser> SystemUser { get; set; }
        public static double DISTANCE_TO_LIGHT_DEVICE = 5.0;
        public Queue<UserPositionHistory> NotAnalizedUserPositionEvents { get; set; }
        public ILightDeviceContr ControllerModule { get; set; }
        public int PreviousStaticPowerLevel { get; set; }

        public DeviceControllingThread(LightDeviceDomain lightDevice)
        {
            LightDevice = lightDevice;
            NotAnalizedUserPositionEvents = new Queue<UserPositionHistory>();
            LastUpdate = DateTime.Now.AddHours(-1);
            SystemUser = new List<Domain.SystemUser>();
            PreviousStaticPowerLevel = lightDevice.MinPercentagePower;
        }

        public void StartControll()
        {
            while (true)
            {
                List<UserPositionHistory> userPossitionToAnalizeNow = new List<UserPositionHistory>();
                bool deviceWasUpdated = false;

                while (NotAnalizedUserPositionEvents.Count > 0)
                    userPossitionToAnalizeNow.Add(NotAnalizedUserPositionEvents.Dequeue());

                using (var repo = new Repository<SystemUser>())
                {
                    SystemUser = repo.All();
                }

                if (userPossitionToAnalizeNow.Count > 0)
                {
                    if (ControllerModule != null)
                        deviceWasUpdated = ControllerModule.ControlDeviceByEvent(userPossitionToAnalizeNow, PreviousStaticPowerLevel, this);
                }

                if (LastUpdate.AddHours(1) <= DateTime.Now && !deviceWasUpdated)
                {
                    List<UserPositionHistory> totalUserPoss = null;

                    using (var repo = new Repository<UserPositionHistory>())
                    {
                        totalUserPoss = repo.Where(p => p.Date >= DateTime.Now.AddHours(-1)).ToList();
                    }

                    int numberOfNearUsers = 0;
                    int totalNumberOfUsers = 0;
                    foreach (var userPoss in totalUserPoss)
                    {
                        SystemUser user = SystemUser.Where(p => p.Mac.Equals(userPoss.Mac)).SingleOrDefault();
                        if (user == null)
                            user = new SystemUser { Mac = userPoss.Mac, UserWeight = 1 };
                        if (DotNetInterface.iCountDistanceBetweenTwoPoints(LightDevice.X, LightDevice.Y, LightDevice.Z, userPoss.X, userPoss.Y, userPoss.Z) < DISTANCE_TO_LIGHT_DEVICE)
                            numberOfNearUsers += user.UserWeight;
                        totalNumberOfUsers += user.UserWeight;
                    }

                    int lightPower = (LightDevice.MaxPercentagePower - LightDevice.MinPercentagePower) * (numberOfNearUsers / totalUserPoss.Count) + LightDevice.MinPercentagePower;

                    ILightDeviceInterface ldInterface = (ILightDeviceInterface)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetName().Name, LightDevice.Interface.InterfaceClassName);
                    ldInterface.NotifyInformationToDevice(LightDevice.Ip, LightDevice.Port, lightPower);
                    PreviousStaticPowerLevel = lightPower;
                    LastUpdate = DateTime.Now;
                    deviceWasUpdated = true;
                }

                if(deviceWasUpdated)
                    Thread.Sleep(100);
            }
        }
    }
}