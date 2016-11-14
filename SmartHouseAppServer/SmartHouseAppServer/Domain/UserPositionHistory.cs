using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouseAppServer.Domain
{
    public class UserPositionHistory
    {
        public virtual int Id { get; set; }
        public virtual string Mac { get; set; }
        public virtual double X { get; set; }
        public virtual double Y { get; set; }
        public virtual double Z { get; set; }
        public virtual DateTime? Date { get; set; }
    }
}