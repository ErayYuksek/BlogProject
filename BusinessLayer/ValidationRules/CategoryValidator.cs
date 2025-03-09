using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adını boş geçemezsiniz")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır")
            .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz");

        }
    }
}
