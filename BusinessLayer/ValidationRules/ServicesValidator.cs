using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ServicesValidator:AbstractValidator<Services>
    {
        public ServicesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Servis adı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Servis açıklaması boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Servis adı 2 karakterden daha fazla olmalı");
            RuleFor(x => x.Description).MinimumLength(2).WithMessage("Servis açıklaması 2 karakterden daha fazla olmalı");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Servis adı 100 karakterden daha az olmalı");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Servis açıklaması 100 karakterden daha az olmalı");
        }
    }
}