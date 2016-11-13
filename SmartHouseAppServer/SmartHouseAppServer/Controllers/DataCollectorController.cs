using SmartHouseApp.Common.DataStractures;
using SmartHouseApp.Common.KnowledgeDataStructures;
using SmartHouseApp.Common.Tools;
using SmartHouseApp.IBuilding.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Serialization;

namespace SmartHouseAppServer.Controllers
{
    public class DataCollectorController : ApiController
    {
        [HttpPost]
        public virtual bool ReportDevices()//[FromBody]DeviceNotificationModel notification)
        {
            SystemDataKnowledge.LoggedUsers[0].Notify("ziom", 50.0, 50.0, 50.0);
            return true;
            //List<SphereData> dataToCalculate = WifiTool.GetRouterSphereData(notification.SignalData.Where(p => p.Type == SignalType.WIFI).ToList());
            //dataToCalculate.AddRange(BluetoothTool.GetBluetoothSphereData(notification.SignalData.Where(p => p.Type == SignalType.BLUETOOTH).ToList()));

            ////var loc = LocationTool.GetLocationWithThreeCircles(new SphereData[] { dataToCalculate[0], dataToCalculate[1], dataToCalculate[2] });
            //Point loc = LocalizationTool.GetProbabilisticLocalization(dataToCalculate);

            //foreach (var loggerUser in SystemDataKnowledge.LoggedUsers)
            //    loggerUser.Notify(notification.SourceName, (double)loc.X, (double)loc.Y, (double)loc.Z);

            //var phone = SystemDataKnowledge.DevicesInfo.Where(p => p.BluetoothMac.Equals(notification.SourceName)).FirstOrDefault();
            //if (phone == null)
            //    phone = new DynamicDeviceInfo() { BluetoothMac = notification.SourceName };

            //phone.CurrentLocation = loc;
            //phone.CurrentLocationUpdateTime = DateTime.Now;
            //phone.CurrentSignalStrengthData = notification.SignalData.ToList();

            //if (loc != null)
            //{
            //    DeviceLocalizationHistory.History.Add(new HistoryData
            //    {
            //        DateOfLocalization = DateTime.Now,
            //        DeviceName = phone.BluetoothMac,
            //        DeviceLocalization = loc
            //    });
            //}

            //return true;
        }
    }
}