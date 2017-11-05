﻿using SocialType.Models;
using SocialType.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
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

                    SendActivationLink <UserAccount> link = new SendActivationLink<UserAccount>();
                    link.SendEmailEventHandler += SendActivation;
                    link.SendEmailToTheUser(account);
                    ViewBag.Message = "Activation successful.";
                }
                ModelState.Clear();
                
                ViewBag.Message = account.FirstName + " " + account.LastName + " Successfully registered.";
             }
            return View(account);
        }

        public void SendActivation(UserAccount account)
        {
            Guid ActivationCode = Guid.NewGuid();

            db.Activations.Add(new UserActivation()
            {
                ActivationCode = ActivationCode,
                UserID = account.UserID
            });

            db.SaveChanges();

            using (MailMessage message = new MailMessage("EMAIL@gmail.com", account.Email))
            {
                message.Subject = "Activate Your Account [SocialTap]";
                string body = "Hello, " + account.FirstName + " if you want to" +
                    " <br>activate your registration</br>, please click on the link below";
                body += "<br><a href= '" + string.Format("{0}://{1}/UserAccount/Activation/{2}", Request.Url.Scheme, Request.Url.Authority, ActivationCode) +
                    "'>Click here to activate your account. </a> </br>";
                body += "<br /><br />Thanks";
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential net = new NetworkCredential("EMAIL@gmail.com", "PASSWORD");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = net;
                smtp.Port = 587;
                smtp.Send(message);


            }

        }
        public ActionResult Activation()
        {
            ViewBag.Message = "Invalid Activation code.";
            if (RouteData.Values["id"] != null)
            {
                Guid activationCode = new Guid(RouteData.Values["id"].ToString());
                UserActivation userActivation = db.Activations.
                    Where(p => p.ActivationCode == activationCode)
                    .FirstOrDefault();
                if (userActivation != null)
                {
                    db.Activations.Remove(userActivation);
                    db.SaveChanges();
                    ViewBag.Message = "Activation successful.";
                }
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
            Regex regex = new Regex("^[a-zA-Z''-'\\s]{1,40}$");
            if (!regex.IsMatch(user.Username))
            {
                ModelState.AddModelError("", "Please check your username it contains illegal characters");
                return View("Login");

            }
            

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
                    FormsAuthentication.SetAuthCookie(user.Username.ToString(), false);
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
            FormsAuthentication.SignOut();
            return View("Loggedout");
        }

        public ActionResult NotLoggedIn()
        {
            return View();
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