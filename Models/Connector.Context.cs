//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OperatorEntities1 : DbContext
    {
        public OperatorEntities1()
            : base("name=OperatorEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abonents> Abonents { get; set; }
        public virtual DbSet<Abonents_equipment> Abonents_equipment { get; set; }
        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<name_service> name_service { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
    }
}
