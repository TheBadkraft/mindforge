using System;

namespace MindForge.Domain.Logging;

/// <summary>
/// Defines a logger interface for logging messages with different log levels.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Logs a message with the specified log level.
    /// </summary>
    /// <param name="level">The level of the log message.</param>
    /// <param name="message">The log message.</param>
    void Log(LogLevel level, string message);

    /// <summary>
    /// Logs a message and an exception with the specified log level.
    /// </summary>
    /// <param name="level">The level of the log message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">The exception to log.</param>
    void Log(LogLevel level, string message, Exception exception);
}
