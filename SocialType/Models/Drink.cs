using System.ComponentModel.DataAnnotations;

namespace SocialType.Models
{
    // TODO kimutis : for all models - restrictions for strings should be added fo length
    public class Drink
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public DrinkType DrinkType { get; set; }
        public int DrinkTypeId { get; set; }

        [Required]
        public int LocationOfDrinkId { get; set; }
        public Location LocationOfDrink { get; set; }

        public double Rating { get; set; }
        public int HowManyTimes { get; set; }
    }
}