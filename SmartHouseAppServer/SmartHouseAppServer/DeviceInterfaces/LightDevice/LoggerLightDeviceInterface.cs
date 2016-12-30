﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SmartHouseAppServer.DeviceInterfaces.LightDevice
{
    public class LoggerLightDeviceInterface : ILightDeviceInterface        
    {
        public bool NotifyInformationToDevice(string ip, string port, int percentage)
        {
            try {
                var request = (HttpWebRequest)WebRequest.Create(string.Format("http://{0}:{1}/", ip, port));

                request.Method = "POST";
                request.ContentType = "text/xml";

                using (StreamWriter stw = new StreamWriter(request.GetRequestStream()))
                {
                    stw.Write(string.Format("Należy ustawić dla urządzenia \"{0}:{1}\" wartość na: {2}%", ip, port, percentage.ToString()));
                }
                //request.ContentLength = request.GetRequestStream().Length;

                request.GetResponseAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}