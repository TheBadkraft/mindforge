using System;

namespace MindForge.TestRunner.Core;

/// <summary>
/// Represents a detector for identifying and managing tests.
/// </summary>
/// <param name="logger">The logger used for logging information and errors.</param>
/// <exception cref="NotImplementedException">Thrown to indicate that the method or operation is not implemented.</exception>
public class TestDetector
{
    private const string CSPROJ = "csproj";
    private const string PATTERN = $"*.{CSPROJ}";

    private ILogger Logger { get; init; }
    private RunnerConfig Config { get; init; }

    public TestDetector(ILogger logger, RunnerConfig config)
    {
        Logger = logger;
        Config = config;
    }

    internal void DiscoverTests()
    {
        Logger.Log(DebugLevel.Default, "Begin Test Discovery ...");
    }
}
