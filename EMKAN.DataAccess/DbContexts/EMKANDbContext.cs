using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMKAN.DataAccess.Model;
using EMKAN.Entity.ModelDto;
using Microsoft.EntityFrameworkCore;
namespace EMKAN.DataAccess.DbContexts
{
    public class EMKANDbContext : DbContext
    {
        public EMKANDbContext(DbContextOptions<EMKANDbContext> Option ) : base(Option) { }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Reply> Reply { get; set; }
        public virtual DbSet<Building> Bulidings { get; set; }
        public virtual DbSet<Branch> Branchs { get; set; }
        public virtual DbSet<AuditTrail> AuditTrails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if (!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder.UseSqlServer("EMKANDb");
            }
        }

    }
}
