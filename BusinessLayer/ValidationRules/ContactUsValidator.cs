using DtoLayer.DTOs.ContactUsDtos;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public ContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail field can not be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field can not be empty");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject field can not be empty");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Subject field can not be less than 5 characters");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Subject field can not more than 100 characters");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Message Body field can not be empty");
        }
    }
}
