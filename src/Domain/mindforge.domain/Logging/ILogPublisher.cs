namespace MindForge.Domain.Logging;

public interface ILogPublisher
{
    event LogEventHandler LogEvent;
    void Log(LogLevel level, string message, Exception exception = null);
}