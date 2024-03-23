using Project_Ngo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Project_Ngo.Models.Dao
{
    public class DonationDAO
    {
        private static DonationDAO instance = null;
        private NGOEntities2 _dbContext; // Thêm biến _dbContext

        private DonationDAO()
        {
            _dbContext = new NGOEntities2(); // Khởi tạo _dbContext trong constructor
        }

        public static DonationDAO Instance
        {
            get
            {
                if (instance == null) { instance = new DonationDAO(); }
                return instance;
            }
        }

        public ICollection<Donations> GetDonation()
        {
            try
            {
                var res1 = _dbContext.Donations.ToList(); // Sử dụng _dbContext
                return res1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void AddDonation(Donations model)
        {
            try
            {
                _dbContext.Donations.Add(model); // Sử dụng _dbContext
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        internal object GetDonationByUserId(int userId)
        {
            var donations = _dbContext.Donations.Where(d => d.UserID == userId).ToList();
            return donations;
        }
    }
}
