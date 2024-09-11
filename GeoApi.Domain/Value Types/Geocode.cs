namespace GeoApi.Domain.ValueTypes
{
    public class Geocode
    {
        public List<Location> Results { get; set; }
    }

    public class Location
    {       
        public string Address { get; set; }
        public string StreetNumber { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Locality { get; set; }
        public string PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }   

}
