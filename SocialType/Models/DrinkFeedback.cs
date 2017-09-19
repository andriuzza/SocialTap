﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class DrinkFeedback
    {
        public int Id { get; set; }
        Drink Drink { get; set; }
        public int Rating { get; set; }
        public string Location { get; set; }
        public int LocationId { get; set; }
    }
}