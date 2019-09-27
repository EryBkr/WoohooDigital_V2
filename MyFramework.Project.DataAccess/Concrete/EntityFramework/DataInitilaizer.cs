using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyFramework.Project.Entities.Concrete;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class DataInitilaizer:DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
           

            List<Role> roles = new List<Role> { new Role { Name="Admin"}, new Role { Name = "User" } };
            foreach (var item in roles)
            {
                context.Role.Add(item);
            }
            context.SaveChanges();

            List<User> users = new List<User> { new User {Name="Black",Password="123456",Roles=new List<Role>{roles[0]},EMail="black@gmail.com"}, new User { Name = "White", Password = "123456", Roles = new List<Role> { roles[1] }, EMail = "white@gmail.com" } };
            foreach (var item in users)
            {
                context.User.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
