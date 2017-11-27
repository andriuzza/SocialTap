using SocialType.Models;
using SocialType.Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
namespace SocialType.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: Notifications
        MyDbContext db;
        public NotificationsController()
        {
            // TODO kimutis : fix it
            db = new MyDbContext();
        }
        public ActionResult Index()
        {
            var CurrentUser = Convert.ToInt32(HttpContextManager.Current.Session["UserID"]);

             var notifications = db.NotificationUsers
                 .Where(q => q.UserAccountUserID == CurrentUser)
                .Select(b => b.Notification)
                .Include(c=> c.Drink)
                .ToList();

            // TODO kimutis : var a?
            var a = notifications.Select(e => e.Drink).ToList();
            return View(a);
        }
    }
}