using SocialType.Models;

namespace SocialType.Services
{
    public class NotificationHandling
    {
        
        public delegate void NewDrinkEventHandler(object o, NotificationEventArgs args);
        public event NewDrinkEventHandler NewDrink;

        public Drink LocalDrink { get; private set; }

        public NotificationHandling()
        {

        }

        public NotificationHandling(Drink Drink)
        {
            LocalDrink = Drink;
            SendNotification.FindSubscribers(this, LocalDrink);
        }

        public virtual void NewDrinkUploaded(NotificationEventArgs noti)
        {
            if (NewDrink != null)
            {
                NewDrink(this, noti);
            }
        }
       

    }
}