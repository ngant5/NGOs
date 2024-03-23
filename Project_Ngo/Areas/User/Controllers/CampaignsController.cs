using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.User.Controllers
{
    public class CampaignsController : Controller
    {
        // GET: User/Campaigns
        public ActionResult Index()
        {
            return View();
        }
    }
}