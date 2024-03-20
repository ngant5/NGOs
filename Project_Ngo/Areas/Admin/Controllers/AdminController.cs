using Project_Ngo.Models.Dao;
using Project_Ngo.Models.Entities;
using Project_Ngo.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Logic xác thực tên đăng nhập và mật khẩu ở đây
            if (username == "admin" && password == "admin")
            {
                // Đăng nhập thành công, chuyển hướng đến trang chính
                return RedirectToAction("Users", "Admin");
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }
       public ActionResult Table()
        {
            ViewBag.Users = UserDao.Instance.GetUser();
            ViewBag.Donations = DonationDao.Instance.GetDonation();
            ViewBag.campaigns = CampaignsDao.Instance.GetCampaigns();
            return View();
        }
        public ActionResult Users()
        {
            ViewBag.Users = UserDao.Instance.GetUser();
            return View();
        }
        public ActionResult Donations()
        {
            ViewBag.Donations = DonationDao.Instance.GetDonation();
            return View();
        }
        public ActionResult Campaigns()
        {
            ViewBag.campaigns = CampaignsDao.Instance.GetCampaigns();
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Users model, HttpPostedFileBase image)
        {
            //string dep_name = Request.Form["dep_name"]; // cach lay tu form
            //string dep_name = Request.Params["dep_name"]; // get params
            // string dep_name = model.dep_name; // target : test get value
            UserDao.Instance.AddUser(model, image);
            return RedirectToAction("Table");
        }
        public ActionResult AddDonation(Donations model)
        {
            //string dep_name = Request.Form["dep_name"]; // cach lay tu form
            //string dep_name = Request.Params["dep_name"]; // get params
            // string dep_name = model.dep_name; // target : test get value
            DonationDao.Instance.AddDonation(model);
            return RedirectToAction("Table");
        }
        public ActionResult AddCampaign(Campaigns model)
        {
            //string dep_name = Request.Form["dep_name"]; // cach lay tu form
            //string dep_name = Request.Params["dep_name"]; // get params
            // string dep_name = model.dep_name; // target : test get value
            CampaignsDao.Instance.AddCampaigns(model);
            return RedirectToAction("Table");
        }
        public ActionResult DeleteUser(int id)
        {
            // int idItem = id; // debug
            UserDao.Instance.Delete(id);
            return RedirectToAction("Table");// parameter: action name
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

                    var Users = context.Users.FirstOrDefault(u => u.FullName == Fullname);

                    if (Users != null && Users.Password == Password)
                    {

                        Session.Timeout = 30;
                        Session["Username"] = Users.FullName;
                        Session["UserID"] = Users.UserID;
                        return RedirectToAction("Index");
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
    }
}