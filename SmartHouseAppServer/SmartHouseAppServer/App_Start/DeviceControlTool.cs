using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHouseApp.Common.Tools
{
    public class DeviceControlTool
    {
        public void Start()
        {
            while(true)
            {
                using(var repo = new Repository)
                Thread.Sleep(1000);
            }
        }
    }
}
