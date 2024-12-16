using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Maintenance.Application.Abstractions.Data;
using MyAutoTrack.Modules.Maintenance.Domain.Maintenances;

namespace MyAutoTrack.Modules.Maintenance.Application.Maintenances.CreateMaintenance;

internal sealed class CreateMaintenanceCommandHandler(
    IMaintenanceRepository maintenanceRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateMaintenanceCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
    { // Criar regras de negocio para consultar itens da manuntenção, calcular o preco total dado a request
        var maintenance = Domain.Maintenances.Maintenance.Create(request.Vehicle, request.VehicleId, request.Status,
            request.Mileage, request.TotalPrice, request.Description, request.MaintenanceItems);

        maintenanceRepository.Insert(maintenance);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return maintenance.Id;
    }
}