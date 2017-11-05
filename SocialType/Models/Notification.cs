using System.ComponentModel.DataAnnotations;

namespace SocialType.Models
{
    public class Notification
    {

        public int Id { get; set; }
        public Drink Drink { get; set; }
        public Location Location { get; set; }
    }
}