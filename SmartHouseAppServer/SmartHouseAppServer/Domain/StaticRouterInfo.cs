using SmartHouseAppServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseAppServer.Domain
{
    public class StaticRouterInfo
    {
        public virtual int Id { get; set; }
        public virtual string SSID { get; set; }
        public virtual double TrasmitterPower { get; set; }
        public virtual double AntennaGain { get; set; }
        public virtual double FadeMargin { get; set; }
        public virtual double LocationX { get; set; }
        public virtual double LocationY { get; set; }
        public virtual double LocationZ { get; set; }
        public virtual int Weight { get; set; }
        public virtual RouterType RouterType { get; set; }

        public virtual double GetSigmaForSignalStrength(double signalStrength)
        {
            return 0.5;
        }
    }
}
