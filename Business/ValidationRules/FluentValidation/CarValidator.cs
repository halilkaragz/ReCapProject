using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Araç adı en az iki karakter olmalı");
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(50).When(c => c.BrandId == 5);
            //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Araba adları A harfi ile başlamalı"); //araba adı A ile başlasın
        }

        //Araba adının A ile başlaması için gereken metot
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
