using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Client.Model
{
    public class PointOnMap
    {
        public double X { get; set; }
        public double Y { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
