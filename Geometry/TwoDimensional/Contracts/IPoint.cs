using Geometry.TwoDimensional.Transformers;

namespace Geometry.TwoDimensional.Contracts
{
    public interface IPoint
    {
        double X { get; }
        double Y { get; }
        public CoordinateSystems SRID { get; }

        //IPoint Add(IVector v);
        //IVector GetVectorFromTo(IPoint from, IPoint to);
        double GetDistance(IPoint b);
        //bool Equals(IPoint b);
    }
}
