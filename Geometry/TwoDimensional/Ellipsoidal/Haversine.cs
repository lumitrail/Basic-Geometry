using static Geometry.UnitConverter;

namespace Geometry.TwoDimensional.Ellipsoidal
{
    /// <summary>
    /// Calculates distance of two points on earth.
    /// </summary>
    /// <remarks>https://gist.github.com/jammin77</remarks>
    public static class Haversine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double GetDistanceInMeter(GeoPoint pos1, GeoPoint pos2)
        {
            ArgumentNullException.ThrowIfNull(pos1);
            ArgumentNullException.ThrowIfNull(pos2);

            double R = 6371000; // earth radius in meter

            double dLat = DegreeToRadian(pos2.Y - pos1.Y);
            double dLon = DegreeToRadian(pos2.X - pos1.X);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreeToRadian(pos1.Y)) * Math.Cos(DegreeToRadian(pos2.Y)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }
    }
}
