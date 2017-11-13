using System;
using System.ComponentModel.DataAnnotations;

namespace SocialType.Models
{
    public class UserActivation
    {
     
        [Key]
        public int UserID { get; set; }
        public Guid ActivationCode { get; set; }
    }
}