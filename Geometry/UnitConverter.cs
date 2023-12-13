using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public static class UnitConverter
    {
        /// <summary>
        /// 360 degree -> radian
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public static double DegreeToRadian(double degree)
        {
            return (Math.PI / 180) * degree;
        }

        /// <summary>
        /// radian -> 360 degree
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static double RadianToDegree(double radian)
        {
            return (180 / Math.PI) * radian;
        }


        /// <summary>
        /// km/h -> m/s
        /// </summary>
        /// <param name="kmph"></param>
        /// <returns></returns>
        public static double KmphToMps(double kmph)
        {
            return kmph / 3.6;
        }

        /// <summary>
        /// m/s -> km/h
        /// </summary>
        /// <param name="mps"></param>
        /// <returns></returns>
        public static double MpsToKmph(double mps)
        {
            return mps * 3.6;
        }
    }
}
