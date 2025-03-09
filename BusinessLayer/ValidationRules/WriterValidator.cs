using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Yazar Adı Soyadı kısmı boş gecilemez");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail kısmı boş gecilemez");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre Soyadı kısmı boş gecilemez");
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("İsim 2 krakter den az olamaz");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("50 Karakterden fazla olamaz");
        }
    }
}
