using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geometry.TwoDimensional.Contracts;
using Geometry.TwoDimensional.Ellipsoidal;
using Geometry.TwoDimensional.Transformers;

namespace Geometry.TwoDimensional.Euclidean
{
    public class FlatPoint : IPoint
    {
        public double X { get; }
        public double Y { get; }
        public CoordinateSystems SRID { get; }


        public FlatPoint(double x, double y, CoordinateSystems srid)
        {
            X = x;
            Y = y;
            SRID = srid;
        }


        public bool TryTransformToEllipsoidal(CoordinateSystems srid, [MaybeNullWhen(false)] out GeoPoint resultPoint)
        {
            return Transformers.Transformer.TryTransformFlatToEllipsoidal(this, srid, out resultPoint);
        }

        public bool TryTransformToFlat(CoordinateSystems srid, [MaybeNullWhen(false)] out FlatPoint resultPoint)
        {
            return Transformers.Transformer.TryTransformFlatToFlat(this, srid, out resultPoint);
        }


        public double GetDistance(IPoint targetPoint)
        {
            ArgumentNullException.ThrowIfNull(targetPoint);

            switch (targetPoint.SRID)
            {
                case CoordinateSystems.Epsg4326:
                    FlatPoint targetPointConv = (targetPoint as GeoPoint).Transform(SRID);
                    
                    break;

                case CoordinateSystems.Epsg5179:
                case CoordinateSystems.Epsg5186:

                    break;

                default:
                    throw new NotSupportedException("unknown coordinate system.");
            }
        }

        private double GetDistance([NotNull] FlatPoint targetPoint)
        {
            ArgumentNullException.ThrowIfNull(targetPoint);

        }
    }
}
