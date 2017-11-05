using SocialType.Models;
using System;

namespace SocialType.Services
{
    public class NotificationEventArgs: EventArgs
    {
        public Drink Drink { get; set; }
        public Notification Notification { get; set; }
    }
}