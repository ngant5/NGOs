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
    
    public partial class Campaigns
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Campaigns()
        {
            this.Donations = new HashSet<Donations>();
        }
    
        public int CampaignsID { get; set; }
        public string NameCampaign { get; set; }
        public Nullable<decimal> GoalAmount { get; set; }
        public Nullable<decimal> CurrentAmount { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donations> Donations { get; set; }
    }
}
