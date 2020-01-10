using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingSite.Models
{
    public class HomeViewModel
    {
        public List<ApplicationUser> users;
        public List<bool> isFriends;
        public List<string> filePath;
    }

}