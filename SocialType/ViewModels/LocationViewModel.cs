using SocialType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.ViewModels
{
    public class LocationViewModel
    {
        public Location loc { get; set; }
        public IEnumerable<Drink> drinks { get; set; }
    }
}