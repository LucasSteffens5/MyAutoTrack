using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Maintenance.Application.Abstractions.Data;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

namespace MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateItem;

internal sealed class CreateItemCommandHandler (IItemRepository itemRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateItemCommand,Guid>
{
    public async Task<Result<Guid>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = Item.Create(request.Name, request.Type, request.Price, request.Inventory);

        itemRepository.Insert(item);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return item.Id;
    }
}
