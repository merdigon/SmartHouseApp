using SmartHouseApp.Common.Repository;
using SmartHouseAppServer.App_Start;
using SmartHouseAppServer.DeviceControllers.LightDevices;
using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;

namespace SmartHouseAppServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static List<DeviceControllingThread> ControllingThreads { get; set; }

        static WebApiApplication()
        {
            ControllingThreads = new List<DeviceControllingThread>();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            using (var repo = new Repository<LightDeviceDomain>())
            {
                var lightDevices = repo.All();

                foreach(var lightDevice in lightDevices)
                {
                    var controllingThread = new DeviceControllingThread(lightDevice);
                    switch(lightDevice.EventModuleName)
                    {
                        case "ImportantUserFirstContr":
                            controllingThread.ControllerModule = new ImportantUserFirstContr();
                            break;
                    }
                    controllingThread.CurrentThread = new Thread(new ThreadStart(controllingThread.StartControll));
                    ControllingThreads.Add(controllingThread);                    
                }
            }
        }
    }
}
