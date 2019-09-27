using MyFramework.Project.DataAccess.Concrete.EntityFramework.Mapping;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext():base("MyFrameworkDB")
        {
            Database.SetInitializer(new DataInitilaizer());
        }

    
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Haber> Haberler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HaberMap());
        }
    }
}
