using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordTransform
{
    class Projection
    {
        private List<float> FROMhd72TOwgs84_p2 = new List<float>() { 6378160, 6356774,516, 6378137, 6356752,3142 };

        private List<float> FROMwgs84TOhd72_p2 = new List<float>() { 6378137, 6356752,3142, 6378160, 6356774,516 };

        private List<float> FROMhd72TOwgs84_p3 = new List<float>() { 52,684, -71,194, -13,975, 0,3120, 0,1063, 0,3729, 0,0000010191 };

        public void eovTOwgs84(decimal a, decimal b)
        {
            List<float> hd72_a = new List<float>();
            hd72_a = eovTOhd72(a, b);
        }

        private List<float> eovTOhd72(decimal b, decimal a)
        {
            List<float> outPut = new List<float>();

            int x = 180 * 3600;


            return outPut;
        }
    }
}
