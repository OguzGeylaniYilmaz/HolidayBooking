using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(i => i.Description).NotEmpty().WithMessage("Desctiption area can not be empty");
            RuleFor(i => i.Description).MinimumLength(50).WithMessage("Desctiption can not be less than 50 characters");
            RuleFor(i => i.Description).MaximumLength(1000).WithMessage("Desctiption can not be more than 1000 characters");
            RuleFor(i => i.Image1).NotEmpty().WithMessage("Please choose an image");
            
        }
    }
}
