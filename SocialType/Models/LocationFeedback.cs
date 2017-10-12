using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SocialType.Models
{
    public class LocationFeedback
    {
        [Key]
        public int Id { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public int UserID { get; set; }
        public UserAccount UserAccount { get; set; }
        public double Rating { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateFeedback { get; set; }
        public string TextFeedback { get; set; }
    }
}