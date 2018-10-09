using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyricsImplementer.Models;

namespace LyricsImplementer.Controllers
{
    public class RegistrationController : Controller
    {
        private LyricsDBContext context = new LyricsDBContext();
        private User user = new User();

        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }

        //Validate logic must be.
        [HttpPost]
        public ActionResult NewUser(User user)
        {
            this.user.Login = user.Login;
            this.user.Password = user.Password;
            this.user.Email = user.Email;
            return View("UsersData");
        }

        [HttpGet]
        public ActionResult UsersData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UsersData(User user)
        {
            user.Login = this.user.Login;
            user.Password = this.user.Password;
            user.Email = this.user.Email;
            if (ModelState.IsValid)
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
                return View("Success");
            }
            
            return View(user);
        }

        [HttpGet]
        public JsonResult CheckLogin(string login)
        {
            var result = false;
            var users = from u in context.Users.AsNoTracking()
                        where u.Login == login
                        select u;
            User user = users.ToList()[0];
            if (user is null)
            {
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckNickname(string Nickname)
        {
            var result = false;
            var nicknames = from n in context.Users.AsNoTracking()
                            where n.Nickname == Nickname
                            select n;
            User user = nicknames.ToList()[0];
            if (user is null)
            {
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CheckEmail(string email)
        {
            var result = false;
            var emails = from e in context.Users.AsNoTracking()
                            where e.Email == email
                            select e;
            User user = emails.ToList()[0];
            if (user is null)
            {
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}