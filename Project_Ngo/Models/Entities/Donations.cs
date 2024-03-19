//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Ngo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Donations
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CampaignsID { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DonationDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    
        public virtual Campaigns Campaigns { get; set; }
        public virtual Users Users { get; set; }
    }
}
