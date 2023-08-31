namespace Rapidata.Application.Services;

public interface IDateTimeProvider
{
    DateTime NowUtc { get; }
}
