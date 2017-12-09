using SocialType.Models;
using System;

namespace SocialType.Services
{
    // TODO kimutis : should be moved to another location
    public class NotificationEventArgs: EventArgs
    {
        public Drink Drink { get; set; }
        public Notification Notification { get; set; }
    }
}