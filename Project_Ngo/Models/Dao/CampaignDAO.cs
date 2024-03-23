using Project_Ngo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Ngo.Models.Dao
{
	public class CampaignDAO
	{
		private static CampaignDAO instance = null;

        private CampaignDAO() { }

        public static CampaignDAO Instance
        {
            get
            {
                if (instance == null) { instance = new CampaignDAO(); }
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
        public IEnumerable<Campaigns> GetCampaignById(int id)
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                var campaignDetails = en.Campaigns.Where(c => c.CampaignsID == id).ToList();
                return campaignDetails;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public Campaigns GetCampaignDetailById(int id)
        {
            try
            {
                NGOEntities2 en = new NGOEntities2();
                var campaign = en.Campaigns.FirstOrDefault(c => c.CampaignsID == id);
                return campaign;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }








    }
}