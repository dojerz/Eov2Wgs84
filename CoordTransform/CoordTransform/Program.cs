using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            Projection conv = new Projection();
            conv.eovTOwgs84(648951, 234344);
        }
    }
}
