﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextBasedRPGGame.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class projectDBEntities : DbContext
    {
        public projectDBEntities()
            : base("name=projectDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Enemy> Enemies { get; set; }
        public virtual DbSet<Hero> Heroes { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<MarketItem> MarketItems { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
