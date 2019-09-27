using FluentValidation;
using MyFramework.Project.Business.ValidationsRules.FluentValidations;
using MyFramework.Project.Entities.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
         
            Bind<IValidator<User>>().To<UserValidator>().InSingletonScope();
            Bind<IValidator<Haber>>().To<HaberValidator>().InSingletonScope();
        }
    }
}
