using MyAutoTrack.Common.Application.Clock;

namespace MyAutoTrack.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
