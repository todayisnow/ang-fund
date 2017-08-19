using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EventsApi.Models
{
    
    public class EventModel
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public LocationModel Location { get; set; }
        public string OnlineUrl { get; set; }
        public List<SessionModel> Sessions { get; set; }
        
    }
    public class LocationModel
    {
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}