using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DrinkType DrinkType { get; set; }
        public int DrinkTypeId { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public int HowManyTimes { get; set; }



        

    }
}