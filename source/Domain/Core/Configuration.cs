using System.Runtime.CompilerServices;

using MindForge.Domain.Logging;

[assembly: InternalsVisibleTo("mindforge.codificer")]
[assembly: InternalsVisibleTo("Codificer.Testing")]


namespace MindForge.Domain.Core;

/// <summary>
/// Provides configuration settings for the application.
/// </summary>
public class Configuration
{
    private static readonly Lazy<Configuration> instance = new Lazy<Configuration>(() => new Configuration(new LogSubject()));

    internal static Configuration Instance => instance.Value;

    /// <summary>
    /// Gets the log subject observer for the application.
    /// </summary>
    public LogSubject LogSubject { get; private set; }
    /// <summary>
    /// Gets or sets the minimum log level for logging.
    /// </summary>
    public LogLevel MinLogLevel { get; set; } = LogLevel.Info;

    /// <summary>
    /// Gets or sets a value indicating whether the application is in debug mode.
    /// </summary>
    public bool IsDebugMode { get; set; }
    /// <summary>
    /// Gets or sets the default logger for the application.
    /// </summary>
    public ILogger DefaultLogger { get; set; }


    private Configuration(LogSubject logSubject)
    {
        LogSubject = logSubject;
    }

    /// <summary>
    /// Initialize the configuration settings.
    /// </summary>
    public static Configuration Initialize()
    {
        Configuration config = Instance;

        //  TODO: implement default configuration initialization

        return config;
    }
    /// <summary>
    /// Loads the configuration settings from a file.
    /// </summary>
    public static Configuration LoadFromFile()
    {
        Configuration config = Instance;

        //  TODO: implement reading from config file

        return config;
    }
    /// <summary>
    /// Saves the current configuration settings to a file.
    /// </summary>
    public void SaveConfig()
    {
        //  TODO: implement saving configuration to file
    }
}
