using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SmartHouseAppServer.Startup))]

namespace SmartHouseAppServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
