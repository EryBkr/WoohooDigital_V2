using MyFramework.Project.Business.Abstract;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.Concrete.Managers
{
    public class RoleManager : IRoleManager
    {
        IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public Role Add(Role entity)
        {
            _roleDal.Add(entity);
            return entity;
        }

        public void Delete(Role entity)
        {
            _roleDal.Delete(entity);
        }

        public Role Get(int id)
        {
            return _roleDal.Get(id);
        }

        public IQueryable<Role> GetAll()
        {
            return _roleDal.GetAll();
        }

        public Role Update(Role entity)
        {
            _roleDal.Update(entity);
            return entity;
        }
    }
}
