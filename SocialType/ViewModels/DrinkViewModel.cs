using SocialType.Models;
using System.Collections.Generic;

namespace SocialType.ViewModels
{
    public class DrinkViewModel
    {
        public Drink Drink { get; set; }

        public int TypeId { get; set; }
        public IEnumerable<DrinkType> TypesDrinks { get; set; }

        public int LocationId { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}