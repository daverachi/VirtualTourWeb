using System.Collections.Generic;

namespace VirtualTourWeb.Models
{
    public class Location
    {
        public Location()
        {
            Areas = new List<Area>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionHtml { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string ImagePath { get; set; }
        public List<Area> Areas { get; set; }
    }
}