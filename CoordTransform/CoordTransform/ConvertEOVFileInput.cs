using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordTransform
{
    class ConvertEOVFileInput
    {
        public List<string> Conversion(string Path)
        {
            Projection conv = new Projection();
            List<string> ResultWgs = new List<string>();

            List<string> input = new List<string>();
            input = System.IO.File.ReadAllLines(Path).ToList();

            foreach (var item in input)
            {
                string[] elements = item.Split(';');
                var eovLat = Convert.ToDouble(elements[0]);
                var eovLon = Convert.ToDouble(elements[1]);
                var address = elements[2];

                List<double> coords = conv.eovTOwgs84(eovLat, eovLon);

                ResultWgs.Add(address + ";" + coords.ElementAt(0) + ";" + coords.ElementAt(1));
            }

            return ResultWgs;
        }
    }
}
