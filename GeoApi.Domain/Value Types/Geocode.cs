namespace GeoApi.Domain.ValueTypes
{
    public class Geocode
    {
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public List<string> AddressComponents { get; set; }
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        public Location Location { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
