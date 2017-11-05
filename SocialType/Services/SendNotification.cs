using SocialType.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialType.Services
{
    public static class SendNotification
    {
        static ICollection<UserAccount> Accounts { get; set; }
        public static void  FindSubscribers(NotificationHandling handler, Drink drink)
        {
            using (MyDbContext db = new MyDbContext())
            {
               Accounts = db.UserAccount.ToList();

                handler.NewDrink += InsertNotification;

                handler.NewDrinkUploaded(CreateNotification(drink));
            }
        }

        private static void InsertNotification(object o, NotificationEventArgs noti)
        {
           using (MyDbContext db = new MyDbContext())
            {
                Notification notification = noti.Notification;
                db.Notifications.Add(notification);

                var users = db.UserAccount.ToList();
                
                foreach(var user in users)
                {
                    NotificationUser ns = new NotificationUser()
                    {
                        UserAccountUserID = user.UserID,
                        NotificationId = notification.Id
                    };
                    db.NotificationUsers.Add(ns);

                }
                db.SaveChanges();
            }
        }
       private static NotificationEventArgs CreateNotification(Drink Drink)
        {
            Notification notification = new Notification();
            using (MyDbContext db = new MyDbContext())
            {
                notification.Drink = Drink;
            }
            return new NotificationEventArgs()
            {
                Notification = notification
            };
        }

    }
}