using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.ViewModels
{
    public class DrinkImageViewModel
    {
        public Drink drinkBottle { get; set; }
        public IEnumerable<DrinkImage> images {get;set;} 
    }
}