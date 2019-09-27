using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Business.Concrete.Managers;
using MyFramework.Project.DataAccess.Abstract;
using MyFramework.Project.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
        

            Bind<IUserManager>().To<UserManager>().InSingletonScope();
            Bind<IUsersDal>().To<EfUserDal>().InSingletonScope();

            Bind<IHaberManager>().To<HaberManager>().InSingletonScope();
            Bind<IHaberDal>().To<EfHaberDal>().InSingletonScope();

        }
    }
}
