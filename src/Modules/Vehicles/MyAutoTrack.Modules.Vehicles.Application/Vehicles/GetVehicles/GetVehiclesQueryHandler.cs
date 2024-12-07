using System.Data.Common;
using Dapper;
using MyAutoTrack.Common.Application.Data;
using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Domain.Vehicles;

namespace MyAutoTrack.Modules.Vehicles.Application.Vehicles.GetVehicles;

internal sealed class GetVehiclesQueryHandler (IDbConnectionFactory dbConnectionFactory): IQueryHandler<GetVehiclesQuery,VehiclesResponse>
{
    public async Task<Result<VehiclesResponse>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();
        
        const string sql =
            $"""
             SELECT DISTINCT
                 v.id AS {nameof(VehiclesResponse.Id)},
                 v.name AS {nameof(VehiclesResponse.Name)},
                 v.description AS {nameof(VehiclesResponse.Description)},
                 v.fabrication_year AS {nameof(VehiclesResponse.FabricationYear)},
                 v.mileage AS {nameof(VehiclesResponse.Mileage)},
                 v.license_plate AS {nameof(VehiclesResponse.LicensePlate)},
                 v.owner_id AS {nameof(VehiclesResponse.OwnerId)},
                 v.Manufacturer_id AS {nameof(VehiclesResponse.ManufacturerId)}
             FROM vehicles.vehicles v
             WHERE v.id = @VehicleId
             """;

        VehiclesResponse? vehicle = (await connection.QuerySingleOrDefaultAsync<VehiclesResponse>(sql, request));
        
        if (vehicle is null)
        {
            return Result.Failure<VehiclesResponse>(VehiclesErrors.NotFound(request.VehicleId));
        }

        return vehicle;
    }
}