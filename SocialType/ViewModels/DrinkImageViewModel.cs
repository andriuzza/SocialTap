using SocialType.Models;
using System.Collections.Generic;

namespace SocialType.ViewModels
{
    public class DrinkImageViewModel
    {
        public Drink DrinkBottle { get; set; }
        public IEnumerable<DrinkImage> Images {get;set;} 
    }
}