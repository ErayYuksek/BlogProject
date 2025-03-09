using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog Başlığını boş geçemezsiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog İçeriğini boş geçemezsiniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog Görselini boş geçemezsiniz");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Lütfen 150 karakterden az karkater kullanın");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen 4 karakterdem daha fazla karkater kullanın");


        }  
    }
}
