using DatingSite.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingSite.Controllers
{
    public class HomeController : Controller
    {


        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            int usersAdded = 0;
            foreach(var user in UserManager.Users)
            {
                if (usersAdded == 3)
                    break;
                users.Add(user);
                usersAdded++;
            }
            HomeViewModel model = new HomeViewModel();
            model.users = users;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}