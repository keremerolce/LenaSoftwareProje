using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LenaProje.Models;

namespace LenaProje.Controllers
{
    public class HomeController : Controller
    {
        LenaDb db = new LenaDb();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Forms.ToList());
        }
        public ActionResult IndexCreate(Form form)
        {
            if (ModelState.IsValid)
            {
                db.Forms.Add(form);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var login = db.Users.Where(u => u.Username == user.Username).SingleOrDefault();
            if (login.Username==user.Username&&login.Password==user.Password)
            {
                Session["username"] = login.Username;
                Session["password"] = login.Password;
                Session["userıd"] = login.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                Session["username"] = user.Username;
                Session["password"] = user.Password;
                Session["userıd"] = user.UserId;
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(user);
            }
            
        }
    }
}