using FluentValidation;

namespace MyAutoTrack.Modules.Vehicles.Application.Owners.CreateOwner;

public class CreateOwnerValidator : AbstractValidator<CreateOwnerCommand>
{
    public CreateOwnerValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}