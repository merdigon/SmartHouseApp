using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseApp.Share.Tools
{
    public class GaussianProbabilityDistribution
    {
        public double Sigma { get; set; }
        public double Um { get; set; }

        public GaussianProbabilityDistribution(double sigma, double um)
        {
            this.Sigma = sigma;
            this.Um = um;
        }

        public double CalculateProbability(double x)
        {
            return Math.Exp(-Math.Pow(x - Um, 2) / (2 * Math.Pow(Sigma, 2))) / Math.Sqrt(2 * Math.PI * Math.Pow(Sigma, 2));
        }
    }
}
