namespace MindForge.Domain.Logging;

/// <summary>
/// Defines a contract for publishing log events.
/// </summary>
public interface ILogPublisher
{
    /// <summary>
    /// Occurs when a log event is published.
    /// </summary>
    event LogEventHandler LogEvent;

    /// <summary>
    /// Logs a message with the specified log level and optional exception.
    /// </summary>
    /// <param name="level">The severity level of the log message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception associated with the log message, if any.</param>
    void Log(LogLevel level, string message, Exception exception = null);
}