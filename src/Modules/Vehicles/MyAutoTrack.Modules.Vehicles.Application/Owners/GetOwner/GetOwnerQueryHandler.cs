using System.Data.Common;
using Dapper;
using MyAutoTrack.Common.Application.Data;
using MyAutoTrack.Common.Application.Messaging;
using MyAutoTrack.Common.Domain;
using MyAutoTrack.Modules.Vehicles.Domain.Owners;

namespace MyAutoTrack.Modules.Vehicles.Application.Owners.GetOwner;

internal sealed class GetOwnerQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetOwnerQuery, OwnerResponse>
{
    public async Task<Result<OwnerResponse>> Handle(GetOwnerQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT DISTINCT
                 v.id AS {nameof(OwnerResponse.Id)},
                v.name AS {nameof(OwnerResponse.Name)},
             FROM vehicles.owners o
             WHERE v.id = @Id
             """;
        
        OwnerResponse? owner = (await connection.QuerySingleOrDefaultAsync<OwnerResponse>(sql, request));
        
        if (owner is null)
        {
            return Result.Failure<OwnerResponse>(OwnersErrors.NotFound(request.OwnerId));
        }

        return owner;
    }
}