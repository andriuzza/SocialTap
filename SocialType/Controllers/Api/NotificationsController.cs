using SocialType.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace SocialType.Controllers.Api
{
    // [Authorize]
    public class NotificationsController : ApiController
    {
        private MyDbContext db;
        public NotificationsController()
        {
            db = new MyDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetData()
        {
            var noti = db.NotificationUsers
                .Select(b => b.Notification)
                 .Include(c => c.Drink)
                 .ToList();


            return Ok(noti);
        }
    }
}
