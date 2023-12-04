using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geometry.TwoDimensional.Contracts;
using Geometry.TwoDimensional.Euclidean;

namespace Geometry.TwoDimensional.Ellipsoidal
{
    public class GeoPoint
    {
        public double X { get; }
        public double Y { get; }
        public int SRID => 4326;

        public GeoPoint(double x, double y)
        {
            X = x;
            Y = y;
        }


        public bool TryTransformTo5179(out FlatPoint? resultPoint)
        {
            return Transformers.Transformer.TryTransformTo5179(this, out resultPoint);
        }
    }
}
