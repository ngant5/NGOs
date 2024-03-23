using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.Admin.Controllers
{
    public class UsersManagerController : Controller
    {
        // GET: Admin/UserManager
        public ActionResult Index()
        {
            return View();
        }
    }
}