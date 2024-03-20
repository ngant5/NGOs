using Project_Ngo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Project_Ngo.Models.Dao
{
	public class CampaignsDao
	{
		private static CampaignsDao instance = null;

        private CampaignsDao() { }

        public static CampaignsDao Instance
        {
            get
            {
                if (instance == null) { instance = new CampaignsDao(); }
                return instance;
            }
        }
		public ICollection<Campaigns> GetCampaigns()
		{
			try
			{
				NGOEntities2 en = new NGOEntities2();
				var res1 = en.Campaigns.ToList();
				return res1;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}
        public void AddCampaigns(Campaigns model)
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                en.Campaigns.Add(model);
                en.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}