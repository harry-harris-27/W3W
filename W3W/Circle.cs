using System;

namespace W3W
{
    public class Circle
    {
        public Circle() { }

        public Circle(LatLng centre, double radius) : this(centre.Latitude, centre.Longitude, radius) { }

        public Circle(double latitude, double longitude, double radius)
        {
            Centre = new LatLng(latitude, longitude);
            Radius = radius;
        }


        public LatLng Centre { get; set; } = new LatLng();

        /// <summary>
        /// Gets or sets the radius or this circle, expressed in km.
        /// </summary>
        public double Radius { get; set; } = 5000;


        public override string ToString() => $"{Centre},{Radius}";
    }
}
