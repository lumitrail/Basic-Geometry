using Geometry.TwoDimensional.Ellipsoidal;
using Geometry.TwoDimensional.Euclidean;
using Geometry.TwoDimensional.Transformers;

namespace runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stops = new List<StopsVirtual>()
            {
                new StopsVirtual(5226, "엑스코 서관 입구 앞", 9, 128.6120991, 35.9067257, 1100350.7285744313, 1768359.2292586567, 345529.81791239476, 368895.99488837435),
                new StopsVirtual(5289, "광덕초등학교", 6, 127.494504, 38.066759, 999517.9036462173, 2007407.106194595, 243394.23036352437, 607525.5193070432),
                new StopsVirtual(5287, "용암초등학교", 2, 127.700021, 38.089366, 1017539.98558649, 2009934.3058644678, 261410.24853823934, 610150.816411),
                new StopsVirtual(5281, "대공원역1", 13, 128.6812894088488, 35.84208395076622, 1106681.056464183, 1761262.477192232, 351899.8106857991, 361827.90280759387),
                new StopsVirtual(5283, "삼거리2(대공원역방면)",13,128.68210463535334,35.83729559517514,1106761.0990235778,1760732.2462096126,351982.6076354617,361297.7996037691),
                new StopsVirtual(5286, "야구전설로", 13, 128.6785855, 35.83406663, 1106447.5699871618, 1760370.2583336208, 351670.76333942043, 360934.0161264054),
                new StopsVirtual(5282, "삼거리1(DIP방면)", 13, 128.6827389, 35.8373976, 1106818.2480860886, 1760744.2527629703, 352039.7256496836, 361310.1048086919),
                new StopsVirtual(5285, "CU 앞", 13, 128.68163576887488, 35.83484253113817, 1106722.0375154328, 1760459.6431301122, 351944.919494714, 361024.8519745391)
            };


        }

        public class StopsVirtual
        {
            public int Id { get; }
            public string Name { get; }
            public int RegionCode { get; }
            //public double Longitude { get; }
            //public double Latitude { get; }
            //public double X5179 { get; }
            //public double Y5179 { get; }
            //public double X5186 { get; }
            //public double Y5186 { get; }

            public GeoPoint GeoPoint { get; }
            public FlatPoint FlatPoint5179 { get; }
            public FlatPoint FlatPoint5186 { get; }


            public StopsVirtual(int id, string name, int regionCode, double longitude, double latitude,
                double x5179, double y5179, double x5186, double y5186)
            {
                Id = id;
                Name = name;
                RegionCode = regionCode;
                //Longitude = longitude;
                //Latitude = latitude;
                //X5179 = x5179;
                //Y5179 = y5179;
                //X5186 = x5186;
                //Y5186 = y5186;

                GeoPoint = new GeoPoint(longitude, latitude);
                FlatPoint5179 = new FlatPoint(x5179, y5179, CoordinateSystems.Epsg5179);
                FlatPoint5186 = new FlatPoint(x5186, y5186, CoordinateSystems.Epsg5186);
            }

            public void PrintDiff()
            {
                {
                    if (GeoPoint.TryTransformToFlat(CoordinateSystems.Epsg5179, out FlatPoint? transPoint))
                    {
                        FlatPoint flatTruth = FlatPoint5179;
                        Console.WriteLine($"Transformation RESULT 4326 -> 5179: diff_x: {flatTruth.X - transPoint.X}, diff_y: {flatTruth.Y - transPoint.Y}");
                    }
                    else
                    {
                        Console.WriteLine("Transformation FAILED 4326 -> 5179");
                    }
                }

                {
                    if (GeoPoint.TryTransformToFlat(CoordinateSystems.Epsg5186, out FlatPoint? transPoint))
                    {
                        FlatPoint flatTruth = FlatPoint5186;
                        Console.WriteLine($"Transformation RESULT 4326 -> 5186: diff_x: {flatTruth.X - transPoint.X}, diff_y: {flatTruth.Y - transPoint.Y}");
                    }
                    else
                    {
                        Console.WriteLine("Transformation FAILED 4326 -> 5186");
                    }
                }
            }
        }
    }
}
