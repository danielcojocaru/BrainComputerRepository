﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrainComputer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BrainGameDBEntities3 : DbContext
    {
        public BrainGameDBEntities3()
            : base("name=BrainGameDBEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Operations> Operations { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
