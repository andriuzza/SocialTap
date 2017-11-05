using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SocialType.Models
{
    public class Location
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Rating { get; set; }

        public ICollection<int> Ratings = new List<int>();

        public ICollection<Drink> Drinks { get; set; }

        public Location()
        {
            Drinks = new Collection<Drink>();
        }
    }
}