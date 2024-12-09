
namespace MindForge.Domain.Logging;

/// <summary>
/// Represents the method that will handle a log event.
/// </summary>
/// <param name="level">The log level of the event.</param>
/// <param name="message">The message to log.</param>
/// <param name="exception">The exception associated with the log event, if any.</param>
public delegate void LogEventHandler(LogLevel level, string message, Exception exception = null);

/// <summary>
/// Represents a log publisher that triggers log events.
/// </summary>
public class LogPublisher : ILogPublisher
{
    /// <summary>
    /// Occurs when a log event is published.
    /// </summary>
    public event LogEventHandler LogEvent;

    /// <summary>
    /// Publishes a log event with the specified log level, message, and optional exception.
    /// </summary>
    /// <param name="level">The log level of the event.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="exception">The exception associated with the log event, if any.</param>
    public void Log(LogLevel level, string message, Exception exception = null)
    {
        LogEvent?.Invoke(level, message, exception);
    }
}
