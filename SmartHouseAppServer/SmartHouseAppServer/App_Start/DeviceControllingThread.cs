using SmartHouseApp.Common.Repository;
using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Xml.Serialization;

namespace SmartHouseAppServer.App_Start
{
    public class DeviceControllingThread
    {
        public DateTime LastUpdate { get; set; }
        public static double DISTANCE_TO_LIGHT_DEVICE = 5.0;

        public DeviceControllingThread()
        {
            LastUpdate = DateTime.Now.AddHours(-1);
        }

        public void StartControll()
        {
            while(true)
            {
                if(LastUpdate.AddHours(1) >= DateTime.Now)
                {
                    List<UserPositionHistory> totalUserPoss = null;
                    List<LightDeviceDomain> lightDevices = null;
                    using (var repo = new Repository<UserPositionHistory>())
                    {
                        totalUserPoss = repo.Where(p => p.Date >= DateTime.Now.AddHours(-1)).ToList();
                    }

                    using (var repo = new Repository<LightDeviceDomain>())
                    {
                        lightDevices = repo.All();
                    }

                    foreach (var device in lightDevices)
                    {
                        int numberOfNearUsers = 0;
                        foreach (var userPoss in totalUserPoss)
                        {
                            if (DotNetInterface.iCountDistanceBetweenTwoPoints(device.X, device.Y, device.Z, userPoss.X, userPoss.Y, userPoss.Z) < DISTANCE_TO_LIGHT_DEVICE)
                                numberOfNearUsers++;
                        }

                        int lightPower = (device.MaxPercentagePower - device.MinPercentagePower) * (numberOfNearUsers / totalUserPoss.Count) + device.MinPercentagePower;

                        var request = (HttpWebRequest)WebRequest.Create(string.Format("http://{0}:{1}//", device.Ip, device.Port));

                        XmlSerializer serializer = new XmlSerializer(typeof(int));

                        request.Method = "POST";
                        request.ContentType = "text/xml";

                        serializer.Serialize(request.GetRequestStream(), lightPower);

                        request.GetResponseAsync();
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}