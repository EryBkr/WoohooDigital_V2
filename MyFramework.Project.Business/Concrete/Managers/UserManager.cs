using MyFramework.Core.Aspects.PostSharp;
using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Business.ValidationsRules.FluentValidations;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.ComplexType;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.Concrete.Managers
{
    public class UserManager : IUserManager
    {
        IUsersDal _userDal;

        public UserManager(IUsersDal usersDal)
        {
            _userDal = usersDal;
        }
        [FluentValidateAspect(typeof(UserValidator))]
        public User Add(User entity)
        {
            _userDal.Add(entity);
            return entity;
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User Get(int id)
        {
            return _userDal.Get(id);
        }

        public IQueryable<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public UserRole GetUserNameAndPassword(string name, string pass)
        {
           return _userDal.GetUserNameAndPassword(name,pass);
        }

        public User Update(User entity)
        {
            _userDal.Update(entity);
            return entity;
        }
    }
}
