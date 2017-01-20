using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Dining.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Dining.DAL
{
    public class DiningContext : DbContext
    {
        public DiningContext() : base("DefaultConnection")
        {
            
        }
        public DbSet<Restaurant> dining_restaurants { get; set; }
        public DbSet<Restaurant_Review> dining_restaurant_reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}