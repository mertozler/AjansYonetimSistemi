using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class PackageValidator:AbstractValidator<Package>
    {
        public PackageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Paket adı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Paket açıklaması boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Paket adı 2 karakterden daha fazla olmalı");
            RuleFor(x => x.Description).MinimumLength(2).WithMessage("Paket açıklaması 2 karakterden daha fazla olmalı");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Paket adı 100 karakterden daha az olmalı");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Paket açıklaması 100 karakterden daha az olmalı");
        }
    }
}