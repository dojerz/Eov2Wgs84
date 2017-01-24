namespace CoordTransform
{
    public class Rootobject
    {
        public string name { get; set; }
        public string type { get; set; }
        public Feature[] features { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public double[][] coordinates { get; set; }
    }

   

    public class Properties
    {
        public string Befogado_epitmeny_tipusa { get; set; }
        public object Befogado_epitmeny_tipusa_egyeb { get; set; }
        public string Befogado_epitmeny_statusza { get; set; }

        public string Color { get; set; }
        public string FillOpacity { get; set; }

    }
}
