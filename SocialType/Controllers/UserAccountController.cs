using SocialType.Models;
using SocialType.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialType.Controllers
{
    public class UserAccountController : Controller
    {

        private MyDbContext db = new MyDbContext();
        // GET: UserAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using(MyDbContext db = new MyDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                
                ViewBag.Message = account.FirstName + " " + account.LastName + " Successfully registered.";
             }
            return View();
        }

        public ActionResult Login()
        {
            
            if (HttpContextManager.Current.Session["UserID"] == null)
            {
                return View("Login");
            } else
            {
                return View("LoggedIn");
            }
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (MyDbContext db = new MyDbContext())
            {
                UserAccount usr = null;
                try
                {
                    usr = db.UserAccount.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                } catch(Exception e)
                {
                    Console.Write(e.StackTrace);
                }

                if(usr != null)
                {
                    HttpContextManager.Current.Session["UserID"] = usr.UserID.ToString();
                    HttpContextManager.Current.Session["Username"] = usr.Username.ToString();
                    return View("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }

            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (HttpContextManager.Current.Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            if (HttpContextManager.Current.Session["UserID"] != null)
            {
                return View("LogOut");
            } else
            {
                return View("NotLoggedIn");
            }
        }

        [HttpPost]
        public ActionResult LogOut(UserAccount user)
        {

            HttpContextManager.Current.Session["UserID"] = null;
            Session["Username"] = null;
            return View("Loggedout");
        }

        public ActionResult NotLoggedIn()
        {
            return View();
        } 

        public ActionResult ShowAllUsers()
        {
            UserAccounts acc = new UserAccounts();
           
            foreach(var user in db.UserAccount.ToList())
            {
                acc.Add(user);
            }
            foreach(UserAccount a in acc)
            {
                Console.WriteLine(a.FirstName);
            }
            return View(acc);
        }

        public MyDbContext getDb()
        {
            return db;
        }

        public void setDb(MyDbContext dbContext)
        {
            db = dbContext;
        }

    }
}