using FluentValidation;

namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.LicensePlate).NotEmpty();
        RuleFor(c => c.Mileage).NotEmpty();
        RuleFor(c => c.OwnerId).NotEmpty();
        RuleFor(c => c.ManufacturerId).NotEmpty();
        RuleFor(c => c.FabricationYear).LessThanOrEqualTo(DateTime.Now.Year);
    }
}