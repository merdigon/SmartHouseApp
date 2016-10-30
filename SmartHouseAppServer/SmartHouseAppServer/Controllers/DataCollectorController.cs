using SmartHouseApp.IBuilding.DataStructure;
using SmartHouseApp.Share.DataStractures;
using SmartHouseApp.Share.KnowledgeDataStructures;
using SmartHouseApp.Share.Tools;
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
        public virtual bool ReportDevices([FromBody]DeviceNotificationModel notification)
        {
            List<SphereData> dataToCalculate = WifiTool.GetRouterSphereData(notification.SignalData.Where(p => p.Type == SignalType.WIFI).ToList());
            dataToCalculate.AddRange(BluetoothTool.GetBluetoothSphereData(notification.SignalData.Where(p => p.Type == SignalType.BLUETOOTH).ToList()));

            //var loc = LocationTool.GetLocationWithThreeCircles(new SphereData[] { dataToCalculate[0], dataToCalculate[1], dataToCalculate[2] });
            Point loc = LocalizationTool.GetProbabilisticLocalization(dataToCalculate);

            var phone = SystemDataKnowledge.DevicesInfo.Where(p => p.BluetoothMac.Equals(notification.SourceName)).FirstOrDefault();
            if (phone == null)
                phone = new DynamicDeviceInfo() { BluetoothMac = notification.SourceName };

            phone.CurrentLocation = loc;
            phone.CurrentLocationUpdateTime = DateTime.Now;
            phone.CurrentSignalStrengthData = notification.SignalData.ToList();

            if (loc != null)
            {
                DeviceLocalizationHistory.History.Add(new HistoryData
                {
                    DateOfLocalization = DateTime.Now,
                    DeviceName = phone.BluetoothMac,
                    DeviceLocalization = loc
                });
            }

            return true;
        }
    }
}