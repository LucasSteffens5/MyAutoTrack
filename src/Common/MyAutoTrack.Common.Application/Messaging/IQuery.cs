using MediatR;
using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;