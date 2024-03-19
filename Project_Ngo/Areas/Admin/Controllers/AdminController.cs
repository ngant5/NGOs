using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Session["UserID"] = "admin123";
            return View();
        }
        public ActionResult ShowAdmin()
        {
            string admin = "";
            if (Session["UserID"] != null)
            {
                admin = Session["UserID"] as string;
            }
            return View();
        }
    }
}