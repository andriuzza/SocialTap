using System.ComponentModel.DataAnnotations;

namespace SocialType.Controllers
{
    public class RatingViewModel
    {
        [Required]
        public double Rating { get; set; }
        [Required]
        public int HowManyTimes { get; set; }
    }
}