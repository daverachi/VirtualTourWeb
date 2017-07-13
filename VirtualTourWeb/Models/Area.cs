using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualTourWeb.Models
{
    public class Area
    {
        public Area()
        {
            Tours = new List<Tour>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionHtml { get; set; }
        public string ImagePath { get; set; }
        public List<Tour> Tours { get; set; }
    }
}