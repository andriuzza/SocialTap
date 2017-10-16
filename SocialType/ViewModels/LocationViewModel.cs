using SocialType.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialType.ViewModels
{
    public class LocationViewModel
    {
        public Location Loc { get; set; }
        public IEnumerable<Drink> Drinks { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Too short name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Too short address")]
        public string Address { get; set;  }
        [Required(ErrorMessage = "{0} is required")]
        public float Latitude { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public float Longitude { get; set; }
        public float Rating { get; set; }
        public ICollection<int> Ratings = new List<int>();
    }
}