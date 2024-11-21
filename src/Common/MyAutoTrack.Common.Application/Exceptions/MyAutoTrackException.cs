using MyAutoTrack.Common.Domain;

namespace MyAutoTrack.Common.Application.Exceptions;

public sealed class MyAutoTrackException(
    string requestName,
    Error? error = default,
    Exception? innerException = default)
    : Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;

    public Error? Error { get; } = error;
}