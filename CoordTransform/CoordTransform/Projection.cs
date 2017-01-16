using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordTransform
{
    class Projection
    {
        private List<decimal> FROMhd72TOwgs84_p2 = new List<decimal>() { 6378160, 6356774.516m, 6378137, 6356752.3142m };

        private List<decimal> FROMwgs84TOhd72_p2 = new List<decimal>() { 6378137, 6356752.3142m, 6378160, 6356774.516m };

        private List<decimal> FROMhd72TOwgs84_p3 = new List<decimal>() { 52.684m, -71.194m, -13.975m, 0.3120m, 0.1063m, 0.3729m, 0.0000010191m };

        public void eovTOwgs84(decimal a, decimal b)
        {
            List<decimal> hd72_a = new List<decimal>();
            hd72_a = eovTOhd72(a, b);
        }

        private List<decimal> eovTOhd72(decimal b, decimal a)
        {
            List<decimal> outPut = new List<decimal>();

            double majom = 0;
            double x = 180 * 3600 / Math.PI;
            double c = 1.0007197049;
            double d = 19.048571778;
            double e = d * Math.PI / 180;
            double f = 47.1;
            double g = f * Math.PI / 180;
            double h = 6379296.419;
            double i = 47 + 7 / 60 + 20.0578 / 3600;
            double j = i * Math.PI / 180;
            double k = Convert.ToDouble(a - 200000);
            double l = Convert.ToDouble(b - 650000);
            double m = 2 * (Math.Atan(Math.Exp(k / h)) - Math.PI / 4);


        }
    }
}
