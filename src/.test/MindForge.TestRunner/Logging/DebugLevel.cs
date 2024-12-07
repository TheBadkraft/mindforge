namespace MindForge.TestRunner.Logging;

/// <summary>
/// Specifies the level of debugging information to be logged.
/// </summary>
public enum DebugLevel
{
    /// <summary>
    /// Default debugging level.
    /// </summary>
    Default,

    /// <summary>
    /// Warning level, used for logging warning messages.
    /// </summary>
    Warning,

    /// <summary>
    /// Error level, used for logging error messages.
    /// </summary>
    Error,

    /// <summary>
    /// Fatal level, used for logging critical error messages that indicate a severe failure.
    /// </summary>
    Fatal
}