using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Controllers
{
    public class UserController : Controller
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
        public ActionResult ForgotPassword()
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
            if (username == "admin" && password == "adminpassword")
            {
                // Đăng nhập thành công, chuyển hướng đến trang chính
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }
    }
}