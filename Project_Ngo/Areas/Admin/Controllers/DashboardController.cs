using Project_Ngo.Models.Dao;
using Project_Ngo.Models.Entities;
using Project_Ngo.Views.User;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            // Kiểm tra xem Session["typeUser"] có tồn tại không
            if (Session["typeUser"] != null)
            {
                // Lấy giá trị typeUser từ Session
                bool typeUser = (bool)Session["typeUser"];

                if (typeUser)
                {
                    // Nếu typeUser là true, hiển thị nội dung trang chính
                    return View();
                }
                else
                {
                    // Nếu typeUser là false, chuyển hướng đến trang đăng nhập
                    return RedirectToAction("Login", "User");
                }
            }
            else
            {
                // Nếu không có Session["typeUser"], chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "User");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string Fullname, string Password)
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

                    if (user != null)
                    {
                        if (user.typeUser.HasValue && user.typeUser.Value == true)
                        {
                            if (user.Password == Password)
                            {
                                Session.Timeout = 30;
                                Session["Username"] = user.FullName;
                                Session["UserID"] = user.UserID;
                                Session["typeUser"] = user.typeUser;
                                Debug.WriteLine("Login successful as admin.");

                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                ViewBag.Error = "Invalid username or password.";

                                return RedirectToAction("Login", "Admin");


                            }
                        }
                        else
                        {
                            ViewBag.Error = "You are not authorized to access the admin panel.";
                            return RedirectToAction("Login", "User", new { area = "User" });

                        }
                    }
                    else
                    {
                        ViewBag.Error = "Invalid username or password.";
                        return RedirectToAction("Register", "User", new { area = "User" });

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




        public ActionResult Table()
        {
            ViewBag.Users = UserProfileDao.Instance.GetAll();
            ViewBag.Donations = DonationDAO.Instance.GetDonation();
            ViewBag.campaigns = CampaignDAO.Instance.GetCampaigns();
            return View();
        }
        public ActionResult Users()
        {
            var users = UserProfileDao.Instance.GetAll();
            return View(users);
        }

        public ActionResult Donations()
        {
            ViewBag.Donations = DonationDAO.Instance.GetDonation();
            return View();
        }
        public ActionResult Campaigns()
        {
            ViewBag.campaigns = CampaignDAO.Instance.GetCampaigns();
            return View();
        }
        public ActionResult CampaignDetails()
        {
            var campaigns = CampaignDAO.Instance.GetCampaigns();
            var campaign = campaigns.FirstOrDefault(); // Lấy phần tử đầu tiên từ danh sách
            return View(campaign);
        }


        [HttpPost]
        public ActionResult AddUser(Users model, HttpPostedFileBase image)
        {
            //string dep_name = Request.Form["dep_name"]; // cach lay tu form
            //string dep_name = Request.Params["dep_name"]; // get params
            // string dep_name = model.dep_name; // target : test get value
            UserProfileDao.Instance.AddUser(model, image);
            return RedirectToAction("Table");
        }
        public ActionResult AddDonation(Donations model)
        {
            //string dep_name = Request.Form["dep_name"]; // cach lay tu form
            //string dep_name = Request.Params["dep_name"]; // get params
            // string dep_name = model.dep_name; // target : test get value
            DonationDAO.Instance.AddDonation(model);
            return RedirectToAction("Table");
        }
        public ActionResult AddCampaign(Campaigns model)
        {
            //string dep_name = Request.Form["dep_name"]; // cach lay tu form
            //string dep_name = Request.Params["dep_name"]; // get params
            // string dep_name = model.dep_name; // target : test get value
            CampaignDAO.Instance.AddCampaigns(model);
            return RedirectToAction("Table");
        }
        public ActionResult DeleteUser(int id)
        {
            // int idItem = id; // debug
            UserProfileDao.Instance.Delete(id);
            return RedirectToAction("Table");// parameter: action name
        }
        public ActionResult DonationDetails(int? userId)
        {
            if (userId == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                
                int userIdValue = userId.Value;
                var donations = DonationDAO.Instance.GetDonationByUserId(userIdValue);
                var user = UserProfileDao.Instance.GetById(userIdValue);
                ViewBag.UserFullName = user.FullName;
                return View(donations);
            }
        }



    }
}