//C.Check TaskC.cs file.Use data with our locations and : 
//- Write a method to get distance between two points defined by latitude and longitude.
//- Use one linq statement to print out Top 10 of the furthest locations pairs, e.g. [LocationA, LocationB] = 1234 km
//- Use one linq statement to print out Top 10 of the nearest locations pairs.

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using GeoCoordinatePortable;

//namespace Lessons._15
//{
//    public static class TaskC
//    {
//        private static IList<Location> _locations = new List<Location>();

//        private static double GetDistance(Location loc1, Location loc2)
//        {
//            GeoCoordinate coord1 = new GeoCoordinate(loc1.Latitude, loc1.Longitude);
//            GeoCoordinate coord2 = new GeoCoordinate(loc2.Latitude, loc2.Longitude);

//            return coord1.GetDistanceTo(coord2);
//        }

//        public static void Run()
//        {
//            AddLocations();

//            //var distancesList = your linq to create and print stuff goes here

//            // Show Top 10 the furthest locations, e.g. LocationA - LocationB = 1234 km
//            // Show Top 10 the nearest locations
//            Waiter.WaitForAnyKey();
//        }

//        private static void AddLocations()
//        {
//            AddLocation("Bristol", Latitude: 51.4510814, Longitude: -2.6023963000000094);
//            AddLocation("London", Latitude: 51.5126492, Longitude: -0.08680119999996805);
//            AddLocation("Edinburgh", Latitude: 55.9630308, Longitude: -3.2016700000000355);
//            AddLocation("Melbourne", Latitude: -37.8166123, Longitude: 144.95956439999998);
//            AddLocation("Sydney", Latitude: -33.86267910000001, Longitude: 151.20881480000003);
//            AddLocation("Shanghai", Latitude: 31.200666, Longitude: 121.60033309999994);
//            AddLocation("Brno", Latitude: 49.1970426, Longitude: 16.607348099999967);
//            AddLocation("Berlin", Latitude: 52.5039901, Longitude: 13.330338500000039);
//            AddLocation("Hong Kong", Latitude: 22.2775464, Longitude: 114.1716202);
//            AddLocation("Milan", Latitude: 45.4601332, Longitude: 9.184021499999972);
//            AddLocation("Wellington", Latitude: -41.2818903, Longitude: 174.77612550000003);
//            AddLocation("Singapore", Latitude: 1.2796312, Longitude: 103.8492996);
//            AddLocation("Winterthur", Latitude: 47.5013468, Longitude: 8.724938000000066);
//        }

//        private static void AddLocation(string town, double Latitude, double Longitude)
//        {
//            _locations.Add(new Location { Town = town, Latitude = Latitude, Longitude = Longitude });
//        }
//    }

//    internal class Location
//    {
//        public string Town { get; set; }
//        public double Latitude { get; set; }
//        public double Longitude { get; set; }
//    }
//}