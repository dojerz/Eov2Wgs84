using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordTransform
{
    class Projection
    {
        private List<double> FROMhd72TOwgs84_p2 = new List<double>() { 6378160, 6356774.516, 6378137, 6356752.3142 };

        private List<double> FROMwgs84TOhd72_p2 = new List<double>() { 6378137, 6356752.3142, 6378160, 6356774.516 };

        private List<double> FROMhd72TOwgs84_p3 = new List<double>() { 52.684, -71.194, -13.975, 0.3120, 0.1063, 0.3729, 0.0000010191 };

        public List<double> eovTOwgs84(double a, double b)
        {
            List<double> hd72_a = new List<double>();
            hd72_a = eovTOhd72(a, b);

            List<double> wgsCoord = bursa_wolf(hd72_a, FROMhd72TOwgs84_p2, FROMhd72TOwgs84_p3);

            return wgsCoord;
        }

        private List<double> eovTOhd72(double b, double a)
        {

            double x = 180 * 3600 / Math.PI;
            double c = 1.0007197049;
            double d = 19.048571778;
            double e = d * Math.PI / 180;
            double f = 47.1;
            double g = f * Math.PI / 180;
            double h = 6379296.419;
            double i = 47 + (7.0 / 60.0) + (20.0578 / 3600.0);
            double j = i * Math.PI / 180;
            double k = (a - 200000);
            double l = (b - 650000);


            double m = 2.0 * (Math.Atan(Math.Exp(k / h)) - Math.PI / 4.0);
            double n = l / h;
            double o = 47.0 + (1.0 / 6.0); 
            double p = Math.Asin(Math.Cos(g) * Math.Sin(m) + Math.Sin(g) * Math.Cos(m) * Math.Cos(n));
            double q = Math.Asin(Math.Sin(n) * Math.Cos(m) / Math.Cos(p));
            double r = 0.822824894115397;
            double s = (p - j) * x;
            double t = o * Math.PI / 180;
            double u = 6378160;
            double v = 6356774.516;

            double w = (u * u - v * v) * Math.Cos(t) * Math.Cos(t) / v / v;
            double y = Math.Pow((1 + w), 0.5);

            double z = 1.5 * w * Math.Tan(t) / x;
            double aa = 0.5 * w * (-1 + Math.Tan(t) * Math.Tan(t) - w + 5 * w * Math.Tan(t) * Math.Tan(t)) / y / x / x;
            double ab = t + s * y / x - s * s * z / x + s * s * s * aa / x;
            double ac = e + q / c;

            double ad = ab * 180 / Math.PI;
            double ae = ac * 180 / Math.PI;

            return new List<double>() { ad, ae, 0 };

        }

        private List<double> bursa_wolf(List<double> p1, List<double> p2, List<double> p3)
        {
            double fi_deg = p1[0];
            double la_deg = p1[1];
            double h = p1[2];

            double a1 = p2[0];
            double b1 = p2[1];
            double a2 = p2[2];
            double b2 = p2[3];

            double dX = p3[0];
            double dY = p3[1];
            double dZ = p3[2];
            double eX = p3[3];
            double eY = p3[4];
            double eZ = p3[5];
            double k = p3[6];

            double f = (a1 - b1) / a1;
            double e2 = 2 * f - f * f;
            double fi = fi_deg * Math.PI / 180;
            double la = la_deg * Math.PI / 180;
            double N = a1 / Math.Pow(1 - e2 * Math.Sin(fi) * Math.Sin(fi), 0.5);
            double X = (N + h) * Math.Cos(fi) * Math.Cos(la);
            double Y = (N + h) * Math.Cos(fi) * Math.Sin(la);
            double Z = (N * (1-e2) + h) * Math.Sin(fi);
            double Xv = dX + (1 + k) * (X + deg2rad(eZ / 3600) * Y - deg2rad(eY / 3600) * Z);
            double Yv = dY + (1 + k) * (-X * deg2rad(eZ / 3600) + Y + Z * deg2rad(eX / 3600));
            double Zv = dZ + (1 + k) * (X * deg2rad(eY / 3600) - Y * deg2rad(eX / 3600) + Z);

            double f2 = (a2 - b2) / a2;
            double e22 = 2 * f2 - f2 * f2;
            double ev2 = (a2 * a2 - b2 * b2) / b2 / b2;
            double P = Math.Pow(Xv * Xv + Yv * Yv, 0.5);
            double theta = Math.Atan2(Zv * a2, P * b2);
            double FI2 = Math.Atan2(Zv + ev2 * b2 * Math.Sin(theta) * Math.Sin(theta) * Math.Sin(theta), P - e22 * a2 * Math.Cos(theta) * Math.Cos(theta) * Math.Cos(theta));
            double LA2 = Math.Atan2(Yv, Xv);
            double N2 = a2 / Math.Pow(1 - e22 * Math.Sin(FI2) * Math.Sin(FI2), 0.5);
            double fi2 = rad2deg(FI2);
            double la2 = rad2deg(LA2);
            double h2 = P / Math.Cos(FI2) - N2;

            return new List<double>() { fi2, la2, h2 };

        }

        private double deg2rad(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private double rad2deg(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private List<double> negal(List<double> arr)
        {
            List<double> ret_a = new List<double>();
            foreach (var item in arr)
            {
                ret_a.Add(item * (-1));
            }

            return ret_a;
        }
    }
}
