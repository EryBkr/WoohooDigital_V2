using FluentValidation;
using MyFramework.Project.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Project.Business.ValidationsRules.FluentValidations
{
    public class HaberValidator : AbstractValidator<Haber>
    {
        public HaberValidator()
        {
            RuleFor(p => p.Detay).NotEmpty().WithMessage("Haber Detayı Boş Geçilemez");
            RuleFor(p => p.Baslik).NotEmpty().WithMessage("Haber Başlığı Boş Geçilemez");
            RuleFor(p => p.Resim).NotEmpty().WithMessage("Resim Eklemek Zorundasınız");
            RuleFor(p => p.Resim).Must(ImageControl).WithMessage("Resim uzantısı jpg , png veya gif olabilir");
         
        }

        public bool ImageControl(string imageName)
        {
            if (imageName!=null)
            {
                string[] data = imageName.Split('.');
                var ex = data[1];
                if ((ex == "jpg") || (ex == "png") || (ex == "gif"))
                {
                    return true;
                }
            }
           
            return false;

        }
    }
}
