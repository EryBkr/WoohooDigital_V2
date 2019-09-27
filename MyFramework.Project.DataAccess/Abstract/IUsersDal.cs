using MyFramework.Core.DataAccess.Abstract;
using MyFramework.Project.Entities.ComplexType;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.DataAccess.Abstract
{
    public interface IUsersDal : IGenericDal<User>
    {
        UserRole GetUserNameAndPassword(string name, string pass);
    }
}
