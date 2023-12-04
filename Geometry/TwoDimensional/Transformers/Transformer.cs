using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotSpatial.Projections;
using Geometry.TwoDimensional.Contracts;
using Geometry.TwoDimensional.Ellipsoidal;
using Geometry.TwoDimensional.Euclidean;

namespace Geometry.TwoDimensional.Transformers
{
    internal static class Transformer
    {
        private static readonly ProjectionInfo Proj4326 = ProjectionInfo.FromProj4String("+proj=longlat +datum=WGS84 +no_defs +type=crs");
        private static readonly ProjectionInfo Proj5179 = ProjectionInfo.FromProj4String("+proj=tmerc +lat_0=38 +lon_0=127.5 +k=0.9996 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +type=crs");
        private static readonly ProjectionInfo Proj5186 = ProjectionInfo.FromProj4String("+proj=tmerc +lat_0=38 +lon_0=127 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +type=crs");

        
        public static bool TryTransformTo5179(GeoPoint sourcePoint, out FlatPoint? targetPoint)
        {
            if (sourcePoint == null)
            {
                targetPoint = null;
                return false;
            }

            try
            {
                double[] xy = new double[] { sourcePoint.X, sourcePoint.Y };
                double[] z = new double[] { 0 };
                Reproject.ReprojectPoints(xy, z, Proj4326, Proj5179, 0, 1);

                targetPoint = new FlatPoint(xy[0], xy[1], 5179);
                return true;
            }
            catch
            {
                targetPoint = null;
                return false;
            }
        }
    }
}
