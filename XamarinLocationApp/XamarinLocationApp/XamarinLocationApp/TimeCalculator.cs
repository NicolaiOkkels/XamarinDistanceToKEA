using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLocationApp
{
    public static class TimeCalculator
    {
        public static double DistanceToHours(double distance)
        {
            //Assumed it takes minumum 10 minutes to walk 1 km.
            double kmInMinutes = distance * 10;
            double kmInHours = kmInMinutes / 60;

            return Math.Round(kmInHours);
        }

        public static double ToMinutes(double distance)
        {
            double kmInMinutes = distance * 10;
            double kmInHours = kmInMinutes / 60;
            return Math.Round(kmInHours % 1 * 60);
        }
        public static double DistanceToMinutes(double distance)
        {
            return distance * 10;
        }
    }
}
