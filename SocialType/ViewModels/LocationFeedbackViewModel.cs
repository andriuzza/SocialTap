using SocialType.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialType.ViewModels
{
    public class LocationFeedbackViewModel
    {
        public Location Location { get; set; }
        public IEnumerable<LocationFeedback> LocationFeedbacks { get; set; }
        public int LocationId { get; set; }
        public string FeedBack { get; set; }
        public string User { get; set; }
    }
}