using SmartHouseApp.Common.DataStractures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouseAppServer.Tools
{
    public class LocalizationTool
    {
        public static Point GetProbabilisticLocalization(List<SphereData> dataToCalculate)
        {
            var fSharpDataToCalculateStructure = dataToCalculate.Select(p => 
                new DotNetStruct.Sphere(p.X, p.Y, p.Z, p.Distance, p.Weight,
                    new DotNetStruct.GausianProbabilityDistribution(p.Distance, p.Sigma))).ToArray();
            var userPos = DotNetInterface.iCountPosition(fSharpDataToCalculateStructure);
            return new Point
            {
                X = userPos.Item1.Item1,
                Y = userPos.Item1.Item2,
                Z = userPos.Item1.Item3
            };
        }
    }

    public class SphereData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public int Weight { get; set; }
        public double Distance { get; set; }
        public double Sigma { get; set; }
    }

    //public static class LocationTool
    //{
    //    public static PairOfPoints CountPositionOfTwoCircleIntersection(double p, double r, double a, double b)
    //    {
    //        PairOfPoints result = new PairOfPoints();
    //        if (a != 0)
    //        {
    //            double delt = Math.Pow(r, 2) - Math.Pow(p, 2) - Math.Pow(a, 2) - Math.Pow(b, 2);
    //            result.Y1 = (((-1) * b * delt) + a * Math.Sqrt((4 * Math.Pow(p, 2) * Math.Pow(b, 2)) - Math.Pow(delt, 2) + (4 * Math.Pow(p, 2) * Math.Pow(a, 2)))) / (2 * (Math.Pow(b, 2) + Math.Pow(a, 2)));
    //            result.Y2 = (((-1) * b * delt) - a * Math.Sqrt((4 * Math.Pow(p, 2) * Math.Pow(b, 2)) - Math.Pow(delt, 2) + (4 * Math.Pow(p, 2) * Math.Pow(a, 2)))) / (2 * (Math.Pow(b, 2) + Math.Pow(a, 2)));
    //            result.X1 = (delt + (2 * b * result.Y1)) / ((-2) * a);
    //            result.X2 = (delt + (2 * b * result.Y2)) / ((-2) * a);
    //        }
    //        else
    //        {
    //            result.Y1 = (Math.Pow(r, 2) - Math.Pow(p, 2) - Math.Pow(b, 2)) / ((-2) * b);
    //            result.Y2 = result.Y1;
    //            result.X1 = Math.Sqrt(Math.Pow(p, 2) - Math.Pow(result.Y1, 2));
    //            result.X2 = result.X1 * (-1);
    //        }
    //        return result;
    //    }

    //    public static PairOfPoints CountPositionOfTwoUnglobalCircleIntersection(double p, double r, double a, double b, double c, double d)
    //    {
    //        if (a < c)
    //        {
    //            var result = CountPositionOfTwoCircleIntersection(p, r, (c - a), (d - b));
    //            result.X1 = result.X1 + a;
    //            result.X2 = result.X2 + a;
    //            result.Y1 = result.Y1 + b;
    //            result.Y2 = result.Y2 + b;
    //            return result;
    //        }
    //        else
    //        {
    //            var result = CountPositionOfTwoCircleIntersection(r, p, (a - c), (b - d));
    //            result.X1 = result.X1 + c;
    //            result.X2 = result.X2 + c;
    //            result.Y1 = result.Y1 + d;
    //            result.Y2 = result.Y2 + d;
    //            return result;
    //        }
    //    }

    //    public static Point GetLocationWithThreeCircles(CircleData[] data)
    //    {
    //        var points1 = CountPositionOfTwoUnglobalCircleIntersection(data[0].Distance, data[1].Distance, data[0].X, data[0].Y, data[1].X, data[1].Y);
    //        var points2 = CountPositionOfTwoUnglobalCircleIntersection(data[2].Distance, data[1].Distance, data[2].X, data[2].Y, data[1].X, data[1].Y);
    //        var points3 = CountPositionOfTwoUnglobalCircleIntersection(data[0].Distance, data[2].Distance, data[0].X, data[0].Y, data[2].X, data[2].Y);
    //        return GetLocationPoint(points1, points2, points3);
    //    }

    //    public static Point GetLocationPoint(PairOfPoints point1, PairOfPoints point2, PairOfPoints point3)
    //    {
    //        if (IfIsCloseEnough(point1.X1, point1.Y1, point2, point3))
    //            return new Point { X = (decimal)point1.X1, Y = (decimal)point1.Y1 };
    //        if (IfIsCloseEnough(point1.X2, point1.Y2, point2, point3))
    //            return new Point { X = (decimal)point1.X2, Y = (decimal)point1.Y2 };
    //        if (IfIsCloseEnough(point2.X1, point2.Y1, point1, point3))
    //            return new Point { X = (decimal)point2.X1, Y = (decimal)point2.Y1 };
    //        if (IfIsCloseEnough(point2.X2, point2.Y2, point1, point3))
    //            return new Point { X = (decimal)point2.X2, Y = (decimal)point2.Y2 };
    //        if (IfIsCloseEnough(point3.X1, point3.Y1, point2, point1))
    //            return new Point { X = (decimal)point3.X1, Y = (decimal)point3.Y1 };
    //        if (IfIsCloseEnough(point3.X2, point3.Y2, point2, point1))
    //            return new Point { X = (decimal)point3.X2, Y = (decimal)point3.Y2 };
    //        return null;
    //    }

    //    public static bool IfIsCloseEnough(double x, double y, PairOfPoints point1, PairOfPoints point2)
    //    {
    //        //List<double[]> closePoints = new List<double[]>();
    //        //if (IfPositionsAreClose(x, y, point1.X1, point1.Y1))
    //        //    closePoints.Add(new double[] { point1.X1, point1.Y1 });
    //        //if (IfPositionsAreClose(x, y, point2.X1, point2.Y1))
    //        //    closePoints.Add(new double[] { point2.X1, point2.Y1 });
    //        //if (IfPositionsAreClose(x, y, point2.X2, point2.Y2))
    //        //    closePoints.Add(new double[] { point2.X2, point2.Y2 });
    //        //if (IfPositionsAreClose(x, y, point1.X2, point1.Y2))
    //        //    closePoints.Add(new double[] { point1.X2, point1.Y2 });
    //        //if (closePoints.Count >= 2)
    //        //{
    //        //    //closePoints.Sort(p => Math.Abs(x - p[0]) + Math.Abs(y - p[1])).ToList();
    //        //}
    //        return true;
    //    }

    //    public static bool IfPositionsAreClose(double x1, double y1, double x2, double y2)
    //    {
    //        double approimation = 2;
    //        return (x2 >= x1 - approimation && x2 <= x1 + approimation && y2 >= y1 - approimation && y2 <= y1 + approimation);
    //    }
    //}

    //public class PairOfPoints
    //{
    //    public double X1 { get; set; }
    //    public double X2 { get; set; }
    //    public double Y1 { get; set; }
    //    public double Y2 { get; set; }
    //}    
}
