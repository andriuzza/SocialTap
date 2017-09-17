using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.ViewModels
{
    public class DrinkViewModel
    {
        public Drink Drink { get; set; }
        public IEnumerable<DrinkType> TypesDrinks { get; set; }
    }
}