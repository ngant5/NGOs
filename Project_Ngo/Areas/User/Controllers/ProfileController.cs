using Project_Ngo.Models.Entities;
using Project_Ngo.Models.Dao;
using Project_Ngo.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Donate()
        {
            return View();
        }

        public ActionResult Partners()
        {
            return View();
        }

        public ActionResult HelpCentre()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAccount(Users model, HttpPostedFileBase image)

        {
            UserProfileDao.Instance.NewUser(model, image);
            return RedirectToAction("index");

        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string Fullname, string Password)
        {
            try
            {
                if (string.IsNullOrEmpty(Fullname) || string.IsNullOrEmpty(Password))
                {
                    ViewBag.Error = "Username and password are required fields.";
                    return View("Login");
                }

                using (var context = new NGOEntities2())
                {

                    var user = context.Users.FirstOrDefault(u => u.FullName == Fullname);

                    if (user != null && user.typeUser.HasValue && user.typeUser.Value == false && user.Password == Password )
                    {

                        Session.Timeout = 30;
                        Session["Username"] = user.FullName;
                        Session["UserID"] = user.UserID;
                        ViewBag.campaigns = CampaignDAO.Instance.GetCampaigns();

                        return RedirectToAction("ShowCampaigns");
                    }
                    else
                    {

                        ViewBag.Error = "Invalid username or password.";
                        return View("Login");
                    }
                }
            }
            catch (Exception ex)
            {

                ViewBag.Error = "An error occurred while processing your request. Please try again later.";

                Console.WriteLine(ex.Message);

                return View("Error");
            }
        }

        public ActionResult ShowCampaigns()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.campaigns = CampaignDAO.Instance.GetCampaigns();
                return View();
            }
            else
            {
                
                return RedirectToAction("Index", "User", new { area = "User" });
            }
        }

        public ActionResult ShowCampaignDetails(int? id)
        {
            if (id.HasValue && Session["UserID"] != null)
            {
                var campaign = CampaignDAO.Instance.GetCampaignDetailById(id.Value);

                if (campaign == null)
                {
                    return HttpNotFound();
                }

                return View(campaign);
            }
            else
            {
                return RedirectToAction("Index", "User", new { area = "User" });
            }
        }



        public ActionResult Welcome()
        {

            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                int userID = Session["UserID"] != null ? (int)Session["UserID"] : 0;

                ViewBag.Username = username;
                ViewBag.UserID = userID;

                return View();
            }
            else
            {

                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Account(int? UserID)
        {
            if (Session["Username"] != null)
            {
                if (UserID != null)
                {

                    var user = UserProfileDao.Instance.GetById(UserID.Value);

                    if (user != null)
                    {

                        return View(user);
                    }
                    else
                    {

                        return HttpNotFound();
                    }
                }
                else
                {

                    return HttpNotFound();
                }
            }
            else
            {

                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult UpdateAccount(int? UserID, Users model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                model.UserID = UserID.Value;
                var result = UserProfileDao.Instance.Update(model, image);
                if (result == 1)
                {
                    return View("UpdateSuccessPopup");

                }
                else if (result == 2)
                {
                    return HttpNotFound();
                }
                else
                {
                    ModelState.AddModelError("", "Failed to update user info.");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {

            Session.Clear();
            return RedirectToAction("Index", "User");
        }

        public ActionResult AddDonation(Donations model)
        {
            DonationDAO.Instance.AddDonation(model);
            
            return View("DonationSuccess");
        }
    }
}