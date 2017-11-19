using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialType.Models
{
    public class LocationFeedback
    {

        public int _LocationId;

        public int Id { get; set; }
        public int LocationId
        {
            get { return this._LocationId; }
            set { this._LocationId = value; }
        }
        public string Feedback { get; set; }
        public string User { get; set; }
    }
}