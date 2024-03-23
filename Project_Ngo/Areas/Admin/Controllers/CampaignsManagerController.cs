using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.Admin.Controllers
{
    public class CampaignsManagerController : Controller
    {
        // GET: Admin/CampaignsAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}