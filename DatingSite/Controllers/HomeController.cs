using DatingSite.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Reflection;

namespace DatingSite.Controllers
{
    public class HomeController : Controller
    {


        private ApplicationUserManager _userManager;

        public OwnContext DbManager { get; set; } = new OwnContext();

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
            List<string> filePaths = new List<string>();
            int usersAdded = 0;
            //List<string> extensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif" };
            foreach(var user in UserManager.Users)
            {
                //if (usersAdded == 3)
                    //break;
                users.Add(user);
                usersAdded++;
                var file = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles")).Where(f => f.Contains(user.Id));
                if (file.Count() != 0)
                {
                    var filePath = file.First().Split('\\');
                    var fileName = filePath[filePath.Length - 1];
                    filePaths.Add(fileName);
                } else
                {
                    filePaths.Add("default_profile.jpg");
                }
            }
            HomeViewModel model = new HomeViewModel();
            model.users = users;
            model.filePath = filePaths;
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