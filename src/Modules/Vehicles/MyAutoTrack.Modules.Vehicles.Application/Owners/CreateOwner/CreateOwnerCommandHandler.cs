using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Application.Abstractions.Data;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;

namespace MyAutoTrack.Modules.Vehicles.Application.Owners.CreateOwner;

internal sealed class CreateOwnerCommandHandler(IOwnersRepository ownersRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateOwnerCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = Owner.Create(request.Name, request.OwnerId);

        ownersRepository.Insert(owner);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return owner.Id;
    }
}