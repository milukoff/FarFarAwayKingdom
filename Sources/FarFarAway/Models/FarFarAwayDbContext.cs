using FarFarAway.Models.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FarFarAway.Models
{
    public class FarFarAwayDbContext : DbContext
    {
        public FarFarAwayDbContext() : base("name=FarFarAwayDbContext")
        {
            System.Data.Entity.Database.SetInitializer<FarFarAwayDbContext>(null);
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Message>().Key(m => m.Id);
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
	    }
        public DbSet<StatusModel> Status { get; set; }

    }
}