using Project_Ngo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Project_Ngo.Models.Dao
{
    public class DonationDao
    {
        private static DonationDao instance = null;

        private DonationDao() { }

        public static DonationDao Instance
        {
            get
            {
                if (instance == null) { instance = new DonationDao(); }
                return instance;
            }
        }
        public ICollection<Donations> GetDonation()
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                var res1 = en.Donations.ToList();
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
                NGOEntities2 en = new NGOEntities2();

                en.Donations.Add(model);
                en.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
