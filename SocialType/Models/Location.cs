using System.Collections.Generic;

namespace SocialType.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Rating { get; set; }
        public ICollection<int> Ratings = new List<int>();
    }
}