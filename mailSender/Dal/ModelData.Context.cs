﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mailSender.Dal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class multiMailSendindingEntities : DbContext
    {
        public multiMailSendindingEntities()
            : base("name=multiMailSendindingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<mailList> mailLists { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<senderList> senderLists { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
