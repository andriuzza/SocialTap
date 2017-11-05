using System.Web.Mvc;

namespace SocialType.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult ContactForm()
        {
            return View();
        }
    }
}