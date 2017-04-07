using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoordTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertEOVFileInput FileInput = new ConvertEOVFileInput();
            
            List<string> result = FileInput.Conversion(@"d:\projects\Laca\SzaboI\PluszIgényhelyek\helyek2.csv");

            System.IO.File.WriteAllLines(@"d:\projects\Laca\SzaboI\PluszIgényhelyek\helyekOut.csv", result);

            // GEOJSON-ből

            /*
            Projection conv = new Projection();
            //List<double> wgsCoords = new List<double>();

            //wgsCoords = conv.eovTOwgs84(663890, 222108);


            string geojson = string.Empty;
            //using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\peter.toth10\Source\Repos\Eov2Wgs84\CoordTransform\CoordTransform\Észak-Buda_10_Leges_helyi_szakasz_HFC.json"))
            using (System.IO.StreamReader sr = new System.IO.StreamReader(@"d:\projects\Laca\JarasReRe\Egyben\Budakeszi\Budakeszi járás_01_Igenyhely_GPON.json"))
            {

                geojson = sr.ReadToEnd();
            }

            Rootobject deser = JsonConvert.DeserializeObject<Rootobject>(geojson);

            Rootobject ReCalculatedGeoJson = new Rootobject();
            
            // neveket átírni!!!
            ReCalculatedGeoJson.name = deser.name;
            ReCalculatedGeoJson.type = deser.type;

            List<Feature> recalcFeatures = new List<Feature>();
            foreach (var tFeature in deser.features)
            {
                Feature ReCalcFeature = new Feature();
                ReCalcFeature.type = tFeature.type;
                ReCalcFeature.properties = new Properties() { Color = "#FF0000", FillOpacity = "0.4" };
                Geometry fGeometry = tFeature.geometry;

                Geometry recalcGeometry = new Geometry();
                recalcGeometry.type = fGeometry.type;
                List<double[]> coordList = new List<double[]>();

                foreach (var coordinate in fGeometry.coordinates)
                {
                    var eovLat = coordinate.ElementAt(0);
                    var eovLon = coordinate.ElementAt(1);

                    List<double> coords = conv.eovTOwgs84(eovLat, eovLon);
                    double wgsLat = coords.ElementAt(0);
                    double wgsLon = coords.ElementAt(1);

                    double[] recCoords = new double[2]; 
                    recCoords[0] = wgsLon;
                    recCoords[1] = wgsLat;

                    coordList.Add(recCoords);
                    
                }
                recalcGeometry.coordinates = coordList.ToArray();
                ReCalcFeature.geometry = recalcGeometry;

                recalcFeatures.Add(ReCalcFeature);
            }

            ReCalculatedGeoJson.features = recalcFeatures.ToArray();

            string json = JsonConvert.SerializeObject(ReCalculatedGeoJson, Formatting.Indented);
            */

        }
    }
}
