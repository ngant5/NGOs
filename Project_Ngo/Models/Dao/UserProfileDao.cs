using Project_Ngo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Project_Ngo.Views.User
{
    public sealed class UserProfileDao
    {
        private static UserProfileDao instance = null;
        private UserProfileDao() { }
        public static UserProfileDao Instance
        {
            get
            {
                if (instance == null) { instance = new UserProfileDao(); }
                return instance;
            }
        }
        public ICollection<Users> GetAll()
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                var res = en.Users.ToList(); // select * from user
                return res;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public int Delete(int id)
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                var q = en.Users.Where(d => d.UserID.Equals(id)).FirstOrDefault();
                if (q != null)
                {
                    en.Users.Remove(q);
                    en.SaveChanges();
                    return 1; //delete 
                }
                return 2; // not found the item by id
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                string err = ex.Message;
            }
            return 0; // failed

        }

        public void NewUser(Users model, HttpPostedFileBase imageFile)
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                model.typeUser = false;
                model.NumberAccount = "";


                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks + Path.GetFileName(imageFile.FileName);
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), fileName);
                    imageFile.SaveAs(path);
                    model.image = fileName;
                    // Debug
                    Debug.WriteLine($"File saved successfully to: {path}");

                }

                en.Users.Add(model);
                en.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void NewAdmin(Users model, HttpPostedFileBase imageFile)
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                model.typeUser = true;
                model.NumberAccount = "";


                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    string fileName = DateTime.Now.Ticks + Path.GetFileName(imageFile.FileName);
                    string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), fileName);
                    imageFile.SaveAs(path);
                    model.image = fileName;
                    // Debug
                    Debug.WriteLine($"File saved successfully to: {path}");

                }

                en.Users.Add(model);
                en.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        public int Update(Users model, HttpPostedFileBase imageFile)
        {
            try
            {
                using (NGOEntities2 en = new NGOEntities2())
                {
                    var existingUser = en.Users.FirstOrDefault(d => d.UserID == model.UserID);
                    if (existingUser != null)
                    {
                        // Cập nhật giá trị của phòng ban tồn tại với thông tin từ model
                        existingUser.FullName = model.FullName;
                        existingUser.Email = model.Email;
                        existingUser.Password = model.Password;
                        existingUser.Phone = model.Phone;
                        if (imageFile != null && imageFile.ContentLength > 0)
                        {

                            string fileName = DateTime.Now.Ticks + Path.GetFileName(imageFile.FileName);
                            string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), fileName);
                            imageFile.SaveAs(path);
                            existingUser.image = fileName;
                            // Debug
                            Debug.WriteLine($"File saved successfully to: {path}");
                        }

                        en.SaveChanges();
                        return 1; // Cập nhật thành công
                    }
                    return 2; // Không tìm thấy phòng ban
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi trong phương thức Update của UserDao: {ex}");
                return 0; // Lỗi xảy ra
            }
        }

        internal Users GetById(int id)
        {
            try
            {
                using (NGOEntities2 en = new NGOEntities2())
                {
                    var user = en.Users.FirstOrDefault(d => d.UserID == id);
                    return user;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi trong phương thức GetById của UserDao: {ex}");
                return null;
            }
        }



        internal void AddUser(Users model, HttpPostedFileBase image)
        {
            throw new NotImplementedException();
        }
    }
}