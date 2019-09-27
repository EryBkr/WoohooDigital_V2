
using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.ComplexType;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>, IUsersDal
    {
        public UserRole GetUserNameAndPassword(string name, string pass)
        {
            using (DatabaseContext db=new DatabaseContext())
            {
                var user = db.User.Where(i => i.Name == name && i.Password == pass).Select(i => new UserRole { Id = i.Id,Email=i.EMail, Name = i.Name, Password = i.Password,Roles=i.Roles}).FirstOrDefault();
                if (user!=null)
                {
                    user.myRole = user.Roles.Select(i => new string[] { i.Name }).FirstOrDefault();

                }
               
                return user;
            }
        }
    }
}
