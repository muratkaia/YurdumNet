﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YurdumNet_MasterPage.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YurdumNETEntities : DbContext
    {
        public YurdumNETEntities()
            : base("name=YurdumNETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Degerlendirmeler> Degerlendirmeler { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        public virtual DbSet<Sehirler> Sehirler { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Universiteler> Universiteler { get; set; }
        public virtual DbSet<YurtEkle> YurtEkle { get; set; }
        public virtual DbSet<YurtFotograflari> YurtFotograflari { get; set; }
        public virtual DbSet<Yurtlar> Yurtlar { get; set; }
        public virtual DbSet<YurtOzellikleri> YurtOzellikleri { get; set; }
        public virtual DbSet<YurtSahipleri> YurtSahipleri { get; set; }
    }
}
