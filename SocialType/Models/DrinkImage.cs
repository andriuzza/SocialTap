﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class DrinkImage
    {
       public int Id { get; set; }
       public int DrinkId { get; set; }
       public Byte[] ImageOfDrink { get; set; }
    }
}