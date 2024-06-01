using DtoLayer.DTOs.AnnouncementDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AddAnnouncementDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title field can not be empty");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please enter at least 5 characters");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Please enter no more than 50 characters");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Content field can not be empty");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Please enter at least 5 characters");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Please enter no more than 500 characters");
        }
    }
}
