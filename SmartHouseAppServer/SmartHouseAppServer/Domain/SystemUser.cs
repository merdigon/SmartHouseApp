using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseAppServer.Domain
{
    public class SystemUser
    {
        public virtual int Id { get; set; }
        public virtual string Mac { get; set; }
        public virtual string VisibleName { get; set; }
        public virtual int UserWeight { get; set; }
    }
}