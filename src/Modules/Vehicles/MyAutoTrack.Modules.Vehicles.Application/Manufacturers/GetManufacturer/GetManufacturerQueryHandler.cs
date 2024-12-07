using System.Data.Common;
using Dapper;
using MyAutoTrack.Common.Application.Data;
using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Domain.Manufacturers;

namespace MyAutoTrack.Modules.Vehicles.Application.Manufacturers.GetManufacturer;

internal sealed class GetManufacturerQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetManufacturerQuery, ManufacturerResponse>
{
    public async Task<Result<ManufacturerResponse>> Handle(GetManufacturerQuery request,
        CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT DISTINCT
                 m.id AS {nameof(ManufacturerResponse.Id)},
                 m.name AS {nameof(ManufacturerResponse.Name)}
             FROM vehicles.manufacturers m
             WHERE m.id = @ManufactureId
             """;

        ManufacturerResponse? manufacturer =
            (await connection.QuerySingleOrDefaultAsync<ManufacturerResponse>(sql, request));

        if (manufacturer is null)
        {
            return Result.Failure<ManufacturerResponse>(ManufacturersErrors.NotFound(request.ManufactureId));
        }

        return manufacturer;
    }
}