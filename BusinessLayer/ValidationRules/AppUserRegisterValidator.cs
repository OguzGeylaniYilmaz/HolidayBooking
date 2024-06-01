using DtoLayer.DTOs.AppUserDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field can not be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname field can not be empty");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail field can not be empty");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username field can not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field can not be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword field can not be empty");

            RuleFor(x => x.Username).MinimumLength(4).WithMessage("Please enter at least 5 characters");
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("Please enter maximum 30 characters");
            RuleFor(x => x.Password).Equal(i => i.ConfirmPassword).WithMessage("Passwords do not match");
        }
    }
}
