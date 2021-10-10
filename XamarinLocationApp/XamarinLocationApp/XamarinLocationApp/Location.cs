using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinLocationApp
{
    public class Location
    {

        public Location(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
    }

}
