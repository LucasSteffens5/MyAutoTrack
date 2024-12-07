using FluentValidation;

namespace MyAutoTrack.Modules.Vehicles.Application.Owners.CreateOwner;

internal sealed class CreateOwnerValidator : AbstractValidator<CreateOwnerCommand>
{
    public CreateOwnerValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}