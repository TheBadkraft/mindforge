namespace MindForge.Domain.Logging;

/// <summary>
/// Specifies the level of logging to be performed.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Debug level for detailed troubleshooting information.
    /// </summary>
    Debug,

    /// <summary>
    /// Info level for informational messages that highlight the progress of the application.
    /// </summary>
    Info,

    /// <summary>
    /// Warning level for potentially harmful situations.
    /// </summary>
    Warning,

    /// <summary>
    /// Error level for error events that might still allow the application to continue running.
    /// </summary>
    Error,

    /// <summary>
    /// Fatal level for very severe error events that will presumably lead the application to abort.
    /// </summary>
    Fatal
}