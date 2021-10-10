using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLocationApp
{
    public static class DistanceCalculator
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }

        public static double Distance(double lat1, double lat2, double lon1, double lon2)
        {

            lon1 = ToRadians(lon1);
            lon2 = ToRadians(lon2);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            // Haversine formula
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;

            double a = Math.Pow(Math.Sin(dlat / 2), 2)
                + Math.Cos(lat1) * Math.Cos(lat2)
                * Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in kilometers
            double r = 6371;

            return (c * r);
        }
    }
}
