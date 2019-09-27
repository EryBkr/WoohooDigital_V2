using FluentValidation;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.ValidationsRules.FluentValidations
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı ismi boş olamaz");
        }
    }
}
