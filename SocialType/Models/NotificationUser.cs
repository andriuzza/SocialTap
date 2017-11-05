using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialType.Models
{
    public class NotificationUser
    {
        [Key]
        [Column(Order = 1)]
        public int UserAccountUserID { get; set; }

        public UserAccount UserAccount { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public Notification Notification { get; set; }


        public bool IsRead { get; set; }
    }
}