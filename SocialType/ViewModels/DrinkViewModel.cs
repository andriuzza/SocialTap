using SocialType.Models;
using System.Collections.Generic;

namespace SocialType.ViewModels
{
    public class DrinkViewModel
    {
        public Drink Drink { get; set; }
        public IEnumerable<DrinkType> TypesDrinks { get; set; }
    }
}