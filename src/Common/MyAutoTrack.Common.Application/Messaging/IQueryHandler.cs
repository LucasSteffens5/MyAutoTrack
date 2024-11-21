using MediatR;
using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
