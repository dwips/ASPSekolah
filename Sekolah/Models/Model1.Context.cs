﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sekolah.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JadwalSekolahDBEntities1 : DbContext
    {
        public JadwalSekolahDBEntities1()
            : base("name=JadwalSekolahDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Guru> Gurus { get; set; }
        public virtual DbSet<Jadwal> Jadwals { get; set; }
        public virtual DbSet<Mapel> Mapels { get; set; }
    }
}
