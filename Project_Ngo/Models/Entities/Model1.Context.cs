﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_Ngo.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NGOEntities2 : DbContext
    {
        public NGOEntities2()
            : base("name=NGOEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Campaigns> Campaigns { get; set; }
        public DbSet<Donations> Donations { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
