//C.Check TaskC.cs file.Use data with our locations and : 
//- Write a method to get distance between two points defined by latitude and longitude.
//- Use one linq statement to print out Top 10 of the furthest locations pairs, e.g. [LocationA, LocationB] = 1234 km
//- Use one linq statement to print out Top 10 of the nearest locations pairs.

using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using Castle.Core.Internal;

namespace Lessons._15
{
    public static class TaskC
    {
        private static IList<Location> _locations = new List<Location>();

        private static double GetDistance(Location loc1, Location loc2)
        {
            GeoCoordinate coord1 = new GeoCoordinate(loc1.Latitude, loc1.Longitude);
            GeoCoordinate coord2 = new GeoCoordinate(loc2.Latitude, loc2.Longitude);

            return coord1.GetDistanceTo(coord2);
        }

        public static void Run()
        {
            AddLocations();

            var distancesList = from loc1 in _locations
                from loc2 in _locations
                where !loc1.Equals(loc2)
                select new Distance(){ LocA = loc1, LocB = loc2, Dist = GetDistance(loc1, loc2) };
            distancesList = distancesList.Distinct().ToList();
            distancesList.OrderByDescending(x => x.Dist).Take(10).ForEach(x => Console.WriteLine(x));
            distancesList.OrderBy(x => x.Dist).Take(10).ForEach(x => Console.WriteLine(x));
            
            Waiter.WaitForAnyKey();
        }

        private static void AddLocations()
        {
            AddLocation("Bristol", Latitude: 51.4510814, Longitude: -2.6023963000000094);
            AddLocation("London", Latitude: 51.5126492, Longitude: -0.08680119999996805);
            AddLocation("Edinburgh", Latitude: 55.9630308, Longitude: -3.2016700000000355);
            AddLocation("Melbourne", Latitude: -37.8166123, Longitude: 144.95956439999998);
            AddLocation("Sydney", Latitude: -33.86267910000001, Longitude: 151.20881480000003);
            AddLocation("Shanghai", Latitude: 31.200666, Longitude: 121.60033309999994);
            AddLocation("Brno", Latitude: 49.1970426, Longitude: 16.607348099999967);
            AddLocation("Berlin", Latitude: 52.5039901, Longitude: 13.330338500000039);
            AddLocation("Hong Kong", Latitude: 22.2775464, Longitude: 114.1716202);
            AddLocation("Milan", Latitude: 45.4601332, Longitude: 9.184021499999972);
            AddLocation("Wellington", Latitude: -41.2818903, Longitude: 174.77612550000003);
            AddLocation("Singapore", Latitude: 1.2796312, Longitude: 103.8492996);
            AddLocation("Winterthur", Latitude: 47.5013468, Longitude: 8.724938000000066);
        }

        private static void AddLocation(string town, double Latitude, double Longitude)
        {
            _locations.Add(new Location { Town = town, Latitude = Latitude, Longitude = Longitude });
        }
    }

    internal class Location
    {
        public string Town { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
                return false;
            return Town.Equals(((Location)obj).Town);
        }

        public override int GetHashCode()
        {
            return Town.GetHashCode();
        }
    }

    internal class Distance
    {
        public Location LocA { get; set; }
        public Location LocB { get; set; }
        public double Dist { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Distance))
                return false;
            Distance dist = (Distance) obj;
            return dist.LocA.Equals(LocA) && dist.LocB.Equals(LocB) || dist.LocB.Equals(LocA) && dist.LocA.Equals(LocB);
        }

        public override int GetHashCode()
        {
            return LocA.GetHashCode()*LocB.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Distance between {0} and {1} is {2}.",LocA.Town,LocB.Town,Dist);
        }
    }
}