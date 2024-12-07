using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Application.Abstractions.Data;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;

namespace MyAutoTrack.Modules.Vehicles.Application.Manufacturers.CreateManufacturers;

internal sealed class CreateManufacturersCommandHandler(IManufacturersRepository manufacturersRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateManufacturersCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateManufacturersCommand request, CancellationToken cancellationToken)
    {
        var manufacturer = Manufacturer.Create(request.Name);

        manufacturersRepository.Insert(manufacturer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return manufacturer.Id;
    }
}