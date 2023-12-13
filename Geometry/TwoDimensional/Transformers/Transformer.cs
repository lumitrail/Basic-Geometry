using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public static readonly ProjectionInfo Proj4326 = ProjectionInfo.FromProj4String("+proj=longlat +datum=WGS84 +no_defs +type=crs");
        public static readonly ProjectionInfo Proj5179 = ProjectionInfo.FromProj4String("+proj=tmerc +lat_0=38 +lon_0=127.5 +k=0.9996 +x_0=1000000 +y_0=2000000 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +type=crs");
        public static readonly ProjectionInfo Proj5186 = ProjectionInfo.FromProj4String("+proj=tmerc +lat_0=38 +lon_0=127 +k=1 +x_0=200000 +y_0=600000 +ellps=GRS80 +towgs84=0,0,0,0,0,0,0 +units=m +no_defs +type=crs");

        

        public static bool TryTransformEllipsoidalToFlat(GeoPoint sourcePoint, CoordinateSystems targetSrid,
            [MaybeNullWhen(false)] out FlatPoint resultPoint)
        {
            if (sourcePoint == null)
            {
                resultPoint = null;
                return false;
            }

            try
            {
                (double x, double y) = GetTransformedXY(sourcePoint, targetSrid);
                resultPoint = new FlatPoint(x, y, targetSrid);
                return true;
            }
            catch
            {
                resultPoint = null;
                return false;
            }
        }


        public static bool TryTransformFlatToEllipsoidal(FlatPoint sourcePoint, CoordinateSystems targetSrid,
            [MaybeNullWhen(false)] out GeoPoint resultPoint)
        {
            if (sourcePoint == null)
            {
                resultPoint = null;
                return false;
            }

            try
            {
                (double x, double y) = GetTransformedXY(sourcePoint, targetSrid);
                resultPoint = new GeoPoint(x, y);
                return true;
            }
            catch
            {
                resultPoint = null;
                return false;
            }
        }


        public static bool TryTransformFlatToFlat(FlatPoint sourcePoint, CoordinateSystems targetSrid,
            [MaybeNullWhen(false)] out FlatPoint resultPoint)
        {
            if (sourcePoint == null)
            {
                resultPoint = null;
                return false;
            }

            try
            {
                (double x, double y) = GetTransformedXY(sourcePoint, targetSrid);
                resultPoint = new FlatPoint(x, y, targetSrid);
                return true;
            }
            catch
            {
                resultPoint = null;
                return false;
            }
        }


        public static ProjectionInfo? GetProjectionInfoFromSrid(CoordinateSystems srid)
        {
            switch (srid)
            {
                case CoordinateSystems.Epsg4326:
                    return Proj4326;

                case CoordinateSystems.Epsg5179:
                    return Proj5179;

                case CoordinateSystems.Epsg5186:
                    return Proj5186;

                default:
                    return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePoint"></param>
        /// <param name="targetSrid"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static (double x, double y) GetTransformedXY(IPoint sourcePoint, CoordinateSystems targetSrid)
        {
            double[] resultXy = new double[] { sourcePoint.X, sourcePoint.Y };
            double[] z = new double[] { 0 };

            Reproject.ReprojectPoints(resultXy, z,
                GetProjectionInfoFromSrid(sourcePoint.SRID),
                GetProjectionInfoFromSrid(targetSrid),
                0, 1);

            return (resultXy[0], resultXy[1]);
        }
    }
}
