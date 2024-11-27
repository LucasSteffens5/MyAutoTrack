using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Application.Abstractions.Data;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(
    IVehicleRepository vehicleRepository,
    IOwnersRepository ownersRepository,
    IManufacturersRepository manufacturersRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateVehicleCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var owner = await ownersRepository.GetAsync(request.OwnerId, cancellationToken);

        if (owner is null)
        {
            return Result.Failure<Guid>(OwnerErrors.NotFound(request.OwnerId));
        }

        var manufacturer = await manufacturersRepository.GetAsync(request.ManufacturerId, cancellationToken);

        if (manufacturer is null)
        {
            return Result.Failure<Guid>(ManufacturersErrors.NotFound(request.OwnerId));
        }

        Result<Vehicle> result = Vehicle.Create(
            owner,
            manufacturer, request.Name, 
            request.Description,
            request.FabricationYear,
            request.Mileage,
            request.LicensePlate);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}