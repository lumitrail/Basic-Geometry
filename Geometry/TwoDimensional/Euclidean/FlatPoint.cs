using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Geometry.TwoDimensional.Contracts;

namespace Geometry.TwoDimensional.Euclidean
{
    public class FlatPoint
    {
        public double X { get; }
        public double Y { get; }
        public int SRID { get; }

        public FlatPoint(double x, double y, int srid)
        {
            X = x;
            Y = y;
            SRID = srid;
        }
    }
}
