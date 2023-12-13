using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geometry.TwoDimensional.Contracts;
using Geometry.TwoDimensional.Euclidean;
using Geometry.TwoDimensional.Transformers;

namespace Geometry.TwoDimensional.Ellipsoidal
{
    public class GeoPoint : IPoint
    {
        public double X { get; }
        public double Y { get; }
        public CoordinateSystems SRID => CoordinateSystems.Epsg4326;


        public GeoPoint(double x, double y)
        {
            X = x;
            Y = y;
        }


        public bool TryTransformToFlat(CoordinateSystems srid, [MaybeNullWhen(false)] out FlatPoint resultPoint)
        {
            return Transformers.Transformer.TryTransformEllipsoidalToFlat(this, srid, out resultPoint);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srid"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public FlatPoint Transform(CoordinateSystems srid)
        {
            if (Transformers.Transformer.TryTransformEllipsoidalToFlat(this, srid, out FlatPoint? resultPoint))
            {
                return resultPoint;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
