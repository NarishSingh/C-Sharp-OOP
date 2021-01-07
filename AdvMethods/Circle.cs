using System;

namespace AdvMethods
{
    class Circle
    {
        public static double pi = 3.14;
        public double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Get Area of circle
        /// </summary>
        /// <returns>double - area of the circle</returns>
        public double getArea()
        {
            return pi * Math.Pow(radius, 2);
        }
    }
}