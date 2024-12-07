using FluentValidation;

namespace MyAutoTrack.Modules.Vehicles.Application.Manufacturers.CreateManufacturer;

internal sealed class CreateManufacturerValidator : AbstractValidator<CreateManufacturerCommand>
{
    public CreateManufacturerValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}