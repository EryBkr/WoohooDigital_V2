using MyFramework.Core.DataAccess.EntityFramework;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.DataAccess.Concrete.EntityFramework
{
    public class EfHaberDal:EfEntityRepositoryBase<Haber,DatabaseContext>,IHaberDal
    {
    }
}
